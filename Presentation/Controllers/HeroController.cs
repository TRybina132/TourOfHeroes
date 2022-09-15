using AutoMapper;
using Domain.Entities;
using Messaging.Producers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Presentation.Filters;
using Presentation.ViewModels.Hero;
using Service.ServicesAbstractions;

namespace Presentation.Controllers
{
    [Route("api/hero")]
    [Authorize]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService service;

        //  REGISTER SERVICE!!!!
        private readonly IMessageProducer messageProducer;
        private readonly IMapper mapper;

        public HeroController(
            IHeroService service,
            IMapper mapper,
            IMessageProducer messageProducer)
        {
            this.service = service;
            this.mapper = mapper;
            this.messageProducer = messageProducer;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<HeroViewModel>> GetAllHeroes()
        {
            var result = await service.GetAllHeroes();
            var viewModels = new List<HeroViewModel>();
            foreach (var hero in result)
                 viewModels.Add(mapper.Map<HeroViewModel>(hero));

            messageProducer.SendMessage<List<HeroViewModel>>(viewModels);

            return viewModels;
        }

        [HttpGet("{id}")]
        [ExceptionFilterFactory]
        public async Task<Hero> GetHeroById([FromRoute] int id) =>
            await service.GetHeroById(id);

        [HttpPost]
        public async Task AddHero([FromBody] HeroCreateViewModel hero) =>
            await service.AddHero(mapper.Map<Hero>(hero));

        [HttpPost("send")]
        public async Task SendHeroes()
        {
            var heroes = await service.GetAllHeroes();
            var mappedHeroes = mapper.Map<List<Hero>>(heroes);

            messageProducer.SendMessage(mappedHeroes);
        }
    }
}
