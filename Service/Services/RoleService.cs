using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Service.ServicesAbstractions;
using System.Data.Entity;

namespace Service.Services
{
    internal class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly UserManager<User> userManager;

        public RoleService(
            RoleManager<IdentityRole<int>> roleManager,
            UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<List<IdentityRole<int>>> GetRoles() =>
            await roleManager.Roles.ToListAsync();

        public async Task AddUserToRole(int userId, int roleId)
        {
            IdentityRole<int> role = await roleManager.FindByIdAsync(roleId.ToString());
            User user = await userManager.FindByIdAsync(userId.ToString());

            await userManager.AddToRoleAsync(user, role.Name);
        }
    }
}
