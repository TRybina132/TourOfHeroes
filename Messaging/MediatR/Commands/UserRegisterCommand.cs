using Domain.Entities;
using MediatR;

namespace Messaging.MediatR.Commands
{
    public class UserRegisterCommand : IRequest
    {
        public User User { get; set; }

        public UserRegisterCommand(User user)
        {
            User = user;
        }
    }
}
