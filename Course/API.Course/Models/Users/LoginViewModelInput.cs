using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Course.Models.Users
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "the login field is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "the password field is required")]
        public string Password { get; set; }
    }
}
