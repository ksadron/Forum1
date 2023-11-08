using Microsoft.AspNetCore.Mvc;
using System;
namespace Forum.Data
{
    public class User
    {
        public int Id { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string email { get; set; }

/*        [BindProperty]
        public string HashedPassword { get; set; }
        [BindProperty]
        public string HashedEmail { get; set; }
        [BindProperty]
        public string HashedFirstName { get; set; }
        public void OnPost()
        {

            HashedFirstName = BCrypt.Net.BCrypt.HashString(user);

            HashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            HashedEmail = BCrypt.Net.BCrypt.HashString(email);

        }*/
    }

}

