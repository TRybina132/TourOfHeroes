using AutoMapper;
using Presentation.ViewModels.Role;
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
