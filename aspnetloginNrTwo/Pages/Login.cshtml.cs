using aspnetloginNrTwo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetloginNrTwo.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;
        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Pw { get; set; }

        public IActionResult OnPost()
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == UserName);
            if(user == null || user.Pw != Pw)
            {
                ModelState.AddModelError("UserName", "Could not find user");
                return Page();
            }

            HttpContext.Session.SetString("LoggedInUser", user.UserName);
            return RedirectToPage("/Index");
        }
            public void OnGet()
        {
        }
    }
}
