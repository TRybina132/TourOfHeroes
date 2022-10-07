using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using Presentation.ViewModels.Role;
using Presentation.ViewModels.User;
using Service.ServicesAbstractions;
using Services.Responses;

namespace Presentation.Controllers
{
    [Route("api/auth")]
    [Authorize]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly UserManager<User> userManager;

        public AuthController(
            IAuthService authService, 
            IMapper mapper,
            IMediator mediator,
            UserManager<User> userManager)
        {
            this.authService = authService;
            this.mapper = mapper;
            this.mediator = mediator;
            this.userManager = userManager;
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
            //  ᓚᘏᗢ Everything is working, just password check
            await userManager.CreateAsync(mapper.Map<User>(user), user.Password);
            AuthResponse response = await authService.Login(user.UserName, user.Password, true);
            
            if (response.IsSuccess)
            {
                //  ᓚᘏᗢ Signing in
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                response.Claims,
                response.Properties);
            }
            userManager.Dispose();
            return mapper.Map<AuthResposeViewModel>(response);
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
