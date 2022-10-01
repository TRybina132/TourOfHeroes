using MediatR;
using Messaging.MediatR.Notifications;
using Service.ServicesAbstractions;

namespace Messaging.MediatR.Handlers
{
    internal class RegisterUserHandler : INotificationHandler<UserRegisterNotification>
    {
        private readonly IUserService userService;

        public RegisterUserHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task Handle(UserRegisterNotification notification, CancellationToken cancellationToken)
        {
            await userService.AddUser(notification.User);
        }
    }
}
