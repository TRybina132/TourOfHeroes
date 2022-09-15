using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Services.Responses
{
    public class AuthResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public ClaimsPrincipal? Claims { get; set; }
        public AuthenticationProperties? Properties { get; set; }
    }
}
