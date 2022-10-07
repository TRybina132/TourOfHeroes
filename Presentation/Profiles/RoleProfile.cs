using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Presentation.ViewModels;

namespace Presentation.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole<int>, RoleViewModel>();
        }
    }
}
