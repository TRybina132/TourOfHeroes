using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public List<Hero>? Heroes { get; set; }
    }
}
