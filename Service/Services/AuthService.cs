using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Service.ServicesAbstractions;
using Services.Responses;
using System.Security.Claims;
using System.Text;

namespace Service.Services
{
    internal class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;

        private async Task AddRoles(User user, List<Claim> claims)
        {
            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
                claims.Add(new Claim(ClaimTypes.Role, role));
        }

        private async Task<AuthResponse> LoginExcitingUser(string username, string password)
        {
            User? user = await userRepository.GetByUsername(username);

            if (user is null)
                return new AuthResponse
                {
                    IsSuccess = false,
                    Message = $"There no user with username: {username}"
                };

            if (!await userManager.CheckPasswordAsync(user, password))
                return new AuthResponse { IsSuccess = false, Message = "Passwords don't match" };

            //  ᓚᘏᗢ Process similiar to auth with jwt token, but cookies
            //          will be authomaticaly setted to response header
            List<Claim> claims = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString())
            };

            await AddRoles(user, claims);

            //  ᓚᘏᗢ Claims identity represents current user and their claims
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            //  ᓚᘏᗢ Parameters for token
            AuthenticationProperties authProperties = new AuthenticationProperties
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

        private AuthResponse LoginNewUser(string username, string password)
        {
            var claims = new List<Claim>
            {
                new Claim("username", username)
            };

            //  ᓚᘏᗢ Claims identity represents current user and their claims
            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties authProperties = new AuthenticationProperties
            {
                //  ᓚᘏᗢ Refreshing just like tokens
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1),
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

        public AuthService(
            IUserRepository userRepository,
            UserManager<User> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        public async Task<AuthResponse> Login(
            string username,
            string password,
            bool isNewUser = false) =>
                isNewUser ? LoginNewUser(username, password) : await LoginExcitingUser(username, password);
    }
}
