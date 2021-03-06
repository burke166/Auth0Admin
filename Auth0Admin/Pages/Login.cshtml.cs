using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Auth0Admin.Pages
{
    public class LoginModel : PageModel
    {
        public async Task OnGetAsync(string ReturnUrl = "/Index")
        {
            await HttpContext.ChallengeAsync("Auth0", new AuthenticationProperties() { RedirectUri = ReturnUrl });
        }
    }
}
