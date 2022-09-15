using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels.User;

namespace Presentation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
