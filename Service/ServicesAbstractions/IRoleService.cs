using Microsoft.AspNetCore.Identity;

namespace Service.ServicesAbstractions
{
    public interface IRoleService
    {
        Task AddUserToRole(int userId, int roleId);
        Task<List<IdentityRole<int>>> GetRoles();
    }
}
