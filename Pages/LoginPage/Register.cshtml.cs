using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Forum.Data;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;

namespace Forum.Pages.LoginPage
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User{ get; set; }

        public ApplicationDbContext Context => _context;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("../MainForm/Forum");
        }
        /*public async Task OnGet(string returnUrl = "../MainForm/Forum")
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                   .WithRedirectUri(returnUrl)
                   .Build();
            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }*/
    }
}