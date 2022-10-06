using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using Presentation.ViewModels.User;
using Service.ServicesAbstractions;

namespace Presentation.Controllers
{
    [Route("api/user")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<List<UserViewModel>> GetAllUsers()
        {
            List<User> users = await userService.GetAllUsers();
            return mapper.Map<List<User>, List<UserViewModel>>(users);
        }

        [HttpDelete("{userId}")]
        [Authorize(Roles = "reptiloid")]
        public async Task DeleteUser([FromRoute] int userId)
        {
            await userService.GetAllUsers();
        }
    }
}
