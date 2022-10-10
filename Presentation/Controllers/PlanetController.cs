using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
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
    }
}
