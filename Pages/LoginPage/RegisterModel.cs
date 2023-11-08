/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BCrypt;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Forum.Pages.LoginPage
{
	public class RegisterModel : PageModel
    {
        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string HashedPassword { get; set; }
        [BindProperty]
        public string HashedEmail { get; set; }
        [BindProperty]
        public string HashedFirstName { get; set; }
        [BindProperty]
        public string HashedLastName { get; set; }

        public void OnPost()
        {

                HashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);

                HashedFirstName = BCrypt.Net.BCrypt.HashString(FirstName);

                HashedLastName = BCrypt.Net.BCrypt.HashString(LastName);

                HashedEmail = BCrypt.Net.BCrypt.HashString(Email);

        }

    }
}
*/