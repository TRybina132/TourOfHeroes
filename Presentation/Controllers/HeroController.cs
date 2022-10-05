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
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/hero")]
    [Authorize]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService service;
        private readonly IUserService userService;

        private readonly IMessageProducer messageProducer;
        private readonly IMapper mapper;

        private int? GetCurrentUserId()
        {
            Claim? claim = User.FindFirst(claim => claim.Type == "id");
            return claim != null ? Convert.ToInt32(claim.Value) : null;
        }

        public HeroController(
            IHeroService service,
            IMapper mapper,
            IMessageProducer messageProducer,
            IServiceProvider serviceProvider)
        {
            //  ᓚᘏᗢ If we get service that way it won't be tracked by
            //          child scope in this case, so it won't be disposed
            this.userService = serviceProvider.GetService(typeof(IUserService)) as IUserService;
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

            //messageProducer.SendMessage<List<HeroViewModel>>(viewModels);

            return viewModels;
        }

        [HttpGet("myHeroes")]
        public async Task<List<HeroViewModel>> GetMyHeroes()
        {
            int? userId = GetCurrentUserId();
            
            var heroes = await service.GetHeroesForUser(userId);
            List<HeroViewModel> viewModels = new List<HeroViewModel>();
            foreach (var hero in heroes)
                viewModels.Add(mapper.Map<HeroViewModel>(hero));

            return viewModels;
        }

        [HttpGet("{id}")]
        [ExceptionFilterFactory]
        public async Task<Hero> GetHeroById([FromRoute] int id) =>
            await service.GetHeroById(id);

        [HttpPost]
        public async Task AddHero([FromBody] HeroCreateViewModel hero)
        {
            int? userId = GetCurrentUserId();
            await service.AddHero(mapper.Map<Hero>(hero), userId);
        }

        [HttpPost("send")]
        public async Task SendHeroes()
        {
            var heroes = await service.GetAllHeroes();
            var mappedHeroes = mapper.Map<List<Hero>>(heroes);

            messageProducer.SendMessage(mappedHeroes);
        }

        [HttpPut]
        public async Task UpdateHero([FromBody]HeroUpdateViewModel hero)
        {
            await service.UpdateHero(mapper.Map<Hero>(hero));
        }

        [HttpDelete("{heroId}")]
        public async Task DeleteHero([FromRoute] int heroId)
        {
            await service.RemoveHero(heroId);
        }
    }
}
