using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ServerSmartTest.Services
{
    public class AuthorizationServices
    {
        public async Task Authenticate(string userName)
        {
   
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
   
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
     
            await AuthenticationHttpContextExtensions.SignInAsync(null, CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task Logout()
        {
            await AuthenticationHttpContextExtensions.SignOutAsync(null, CookieAuthenticationDefaults.AuthenticationScheme);
        }

    }
}

