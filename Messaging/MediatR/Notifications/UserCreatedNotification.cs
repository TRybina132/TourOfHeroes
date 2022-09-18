using Domain.Entities;
using MediatR;

namespace Messaging.MediatR.Notifications
{
    public class UserCreatedNotification : INotification
    {
        public User User { get; set; }

        public UserCreatedNotification(User user)
        {
            User = user;
        }
    }
}
