using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizza.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private static readonly UserInfo LoggedOutUser = new UserInfo
        {
            IsAuthenticated = false
        };

        [HttpGet]
        public UserInfo GetUser()
        {
            return User.Identity.IsAuthenticated
                ? new UserInfo { Name = User.Identity.Name, IsAuthenticated = true }
                : LoggedOutUser;
        }

        [HttpGet("signin")]
        public async Task SignIn(string redirectUri)
        {
            if (string.IsNullOrEmpty(redirectUri) || !Url.IsLocalUrl(redirectUri))
            {
                redirectUri = "/";
            }

            await HttpContext.ChallengeAsync(
                GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = redirectUri });
        }

        [HttpGet("signout")]
        public async Task<ActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/");
        }
    }
}