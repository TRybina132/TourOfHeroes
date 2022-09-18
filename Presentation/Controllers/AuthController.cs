using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using System.Security.Claims;
using Services.Responses;
using Service.ServicesAbstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Presentation.ViewModels.User;

namespace Presentation.Controllers
{
    [Route("api/auth")]
    [Authorize]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            this.authService = authService;
            this.mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<AuthResposeViewModel> Login([FromBody] UserLoginViewModel login)
        {
            AuthResponse response = await authService.Login(login.UserName, login.Password);

            if (response.IsSuccess)
            {
                //  ᓚᘏᗢ Signing in
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                response.Claims,
                response.Properties);
            }

            return mapper.Map<AuthResposeViewModel>(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<AuthResposeViewModel> RegisterUser(UserCreateViewModel user)
        {
            return null;
        }

        [HttpGet("user")]
        public List<UserClaim> GetCurrentUser()
        {
            List<UserClaim> userClaims = User.Claims
                .Select(x => new UserClaim(x.Type, x.Value))
                .ToList();

            return userClaims;
        }

        [HttpPost("signOut")]
        public async Task SignOut() =>
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
