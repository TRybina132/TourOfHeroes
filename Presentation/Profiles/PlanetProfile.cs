using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels;

namespace Presentation.Profiles
{
    public class PlanetProfile : Profile
    {
        public PlanetProfile()
        {
            //  ᓚᘏᗢ Replace with creating create view model
            CreateMap<Planet, PlanetViewModel>()
                .ReverseMap();
        }
    }
}
