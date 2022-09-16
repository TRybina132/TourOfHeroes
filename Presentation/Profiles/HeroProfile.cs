using Domain.Entities;
using AutoMapper;
using Presentation.ViewModels.Hero;
using Presentation.ViewModels;

namespace Presentation.Profiles
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<HeroCreateViewModel, Hero>();
            CreateMap<Hero,HeroViewModel>();
            CreateMap<HeroUpdateViewModel, Hero>();
            //CreateMap<List<Hero>, List<HeroViewModel>>();
        }
    }
}
