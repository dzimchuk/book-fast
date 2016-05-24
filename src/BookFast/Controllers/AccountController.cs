using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BookFast.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            return new ChallengeResult(
                OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = "/" });
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.Authentication.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
            return new EmptyResult();
        }
    }
}