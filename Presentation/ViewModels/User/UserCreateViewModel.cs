using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.User
{
    public class UserCreateViewModel
    {
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
