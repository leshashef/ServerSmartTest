using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ServerSmartTest.Services
{
    public class AuthorizationServices
    {
        public async Task Authenticate(string userName, HttpContext context)
        {
   
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
   
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
     
            await AuthenticationHttpContextExtensions.SignInAsync(context, CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task Logout(HttpContext context)
        {
            await AuthenticationHttpContextExtensions.SignOutAsync(context, CookieAuthenticationDefaults.AuthenticationScheme);
        }

    }
}

