using AutoMapper;
using Presentation.ViewModels;
using Services.Responses;

namespace Presentation.Profiles
{
    public class AuthResponseProfile : Profile
    {
        public AuthResponseProfile()
        {
            CreateMap<AuthResponse, AuthResposeViewModel>();
        }
    }
}
