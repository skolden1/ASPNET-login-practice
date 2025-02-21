using aspnetloginNrTwo.Data;
using aspnetloginNrTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetloginNrTwo.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _context;
        public RegisterModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Pw { get; set; }

        [BindProperty]
        public string RepeatPw { get; set; }

        public IActionResult OnPost()
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.UserName == UserName);

            if(existingUser != null)
            {
                ModelState.AddModelError("UserName", "Username already taken, try again");
                return Page();
            }

            if (Pw != RepeatPw)
            {
                ModelState.AddModelError("Pw", "Password didnt match");
                return Page();
            }

            var newUser = new User
            {
                UserName = UserName,
                Pw = Pw
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return RedirectToPage("/home");
            
        }
        public void OnGet()
        {
        }
    }
}
