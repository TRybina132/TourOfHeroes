using Domain.Entities;
using MediatR;

namespace Messaging.MediatR.Notifications
{
    public class UserRegisterNotification : INotification
    {
        public User User { get; set; }

        public UserRegisterNotification(User user)
        {
            User = user;
        }
    }
}
