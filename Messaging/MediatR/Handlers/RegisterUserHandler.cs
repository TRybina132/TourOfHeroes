using MediatR;
using Messaging.MediatR.Commands;
using Service.ServicesAbstractions;

namespace Messaging.MediatR.Handlers
{
    public class RegisterUserHandler : IRequestHandler<UserRegisterCommand>
    {
        private readonly IUserService userService;

        public RegisterUserHandler(IUserService userService)
        {
            this.userService = userService;
        }

        {
        }
    }
}
