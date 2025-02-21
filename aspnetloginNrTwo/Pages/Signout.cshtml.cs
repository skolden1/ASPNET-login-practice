using aspnetloginNrTwo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetloginNrTwo.Pages
{
    public class SignoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("LoggedInUser");
            return RedirectToPage("/Login");
        }
        
    }
}
