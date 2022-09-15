using Domain.Entities;
using AutoMapper;
using Presentation.ViewModels.Hero;

namespace Presentation.Profiles
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<HeroCreateViewModel, Hero>();
            CreateMap<Hero,HeroViewModel>();
            //CreateMap<List<Hero>, List<HeroViewModel>>();
        }
    }
}
