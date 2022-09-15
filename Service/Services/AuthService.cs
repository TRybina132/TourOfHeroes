using Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Service.ServicesAbstractions;
using Services.Responses;
using System.Security.Claims;

namespace Service.Services
{
    internal class AuthService : IAuthService
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        public AuthService(IUserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        public async Task<AuthResponse> Login(string username, string password)
        {
            User user = await userService.GetByUsername(username);

            if (!await userManager.CheckPasswordAsync(user, password))
                return new AuthResponse { IsSuccess = false, Message = "Passwords don't match" };

            //  ᓚᘏᗢ Process similiar to auth with jwt token, but cookies
            //          will be authomaticaly setted to response header

            var claims = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString()),
            };

            //  ᓚᘏᗢ Claims identity represents current user and their claims
            var claimsIdentity = new ClaimsIdentity(
                claims, 
                CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //  ᓚᘏᗢ Refreshing just like tokens
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20),
                //  ᓚᘏᗢ The same cookie will be for multiplie requests
                IsPersistent = true,
                IssuedUtc = DateTimeOffset.UtcNow
            };

            return new AuthResponse 
            { 
                IsSuccess = true,
                Claims = new ClaimsPrincipal(claimsIdentity),
                Properties = authProperties
            }; 
        }
    }
}
