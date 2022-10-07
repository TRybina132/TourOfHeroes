using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using Presentation.ViewModels.Role;
using Service.ServicesAbstractions;

namespace Presentation.Controllers
{
    [Route("/api/role")]
    [Authorize]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleService roleService;
        IMapper mapper;

        public RoleController(
            IRoleService roleService,
            IMapper mapper)
        {
            this.roleService = roleService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<List<RoleViewModel>> GetRoles()
        {
            List<IdentityRole<int>> roles = await roleService.GetRoles();

            return mapper.Map<List<RoleViewModel>>(roles);
        }


        [HttpPost]
        public async Task AddRoleToUser([FromBody] UserRole userRole)
        {
            await roleService.AddUserToRole(userRole.UserId, userRole.RoleId);
        }
    }
}
