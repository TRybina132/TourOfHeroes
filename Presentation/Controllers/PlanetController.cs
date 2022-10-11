using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using Presentation.ViewModels.User;
using Service.ServicesAbstractions;

namespace Presentation.Controllers
{
    [Route("api/planet")]
    [Authorize]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetService planetService;
        private readonly IMapper mapper;

        public PlanetController(IPlanetService planetService, IMapper mapper)
        {
            this.planetService = planetService;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<PlanetViewModel>> GetAllPlanets() =>
            mapper.Map<List<PlanetViewModel>>(await planetService.GetAllPlanets());

        [HttpGet("{id}")]
        public async Task<PlanetViewModel> GetPlanet([FromRoute] int id) =>
            mapper.Map<PlanetViewModel>(await planetService.GetPlanetById(id));

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task AddPlanet([FromBody] PlanetViewModel planet) =>
            await planetService.AddPlanet(mapper.Map<Planet>(planet));

        [HttpGet("byName/{name}")]
        [Authorize]
        public async Task<PlanetViewModel> GetPlanetByName([FromRoute] string name)
        {
            Planet planet = await planetService.GetPlanetByName(name);
            return mapper.Map<PlanetViewModel>(planet);
        }

        [HttpGet("usersFor/{id}")]
        [Authorize(Roles = "admin, reptiloid")]
        public async Task<List<UserViewModel>> GetUsersForPlanet([FromRoute] int id)
        {
            List<User> users = await planetService.GetUsersForPlanet(id);
            return mapper.Map<List<UserViewModel>>(users);
        }
    }
}
