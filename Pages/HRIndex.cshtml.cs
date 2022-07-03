using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    [Authorize(Policy = "MemberOfHR")]
    public class HRIndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
