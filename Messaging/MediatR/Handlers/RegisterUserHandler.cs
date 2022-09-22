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

        public async Task<Unit> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            await userService.AddUser(request.User);
            return Unit.Value;
        }
    }
}
