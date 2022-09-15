using Domain.Entities;

namespace Service.ServicesAbstractions
{
    public interface IUserService
    {
        public Task<User> GetByUsername(string username);
    }
}
