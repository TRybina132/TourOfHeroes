using Domain.Entities;
using MediatR;

namespace Messaging.MediatR.Commands
{
    public class UserRegisterCommand : IRequest
    {
        public User User { get; set; }
        public string Password { get; set; }
        public UserRegisterCommand(User user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
