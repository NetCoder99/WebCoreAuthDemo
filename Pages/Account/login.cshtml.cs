using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using WebApplication1.Security;

namespace WebApplication1.Pages.Account
{
    public class loginModel : PageModel
    {
        [BindProperty]
        public Credential credential { get; set; }

        public async Task<IActionResult> OnGet()
        {
            this.credential = new Credential { UserName = "admin" };
            return Page();
        }

        public async Task<IActionResult> OnPost() {
            if (!ModelState.IsValid) { return Page();  }
            ClaimsPrincipal claimsPrincipal = ValidateCredential.Validate(credential);
            if (claimsPrincipal != null)
            {
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
