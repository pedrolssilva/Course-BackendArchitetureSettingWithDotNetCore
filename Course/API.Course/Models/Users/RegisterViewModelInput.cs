using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Course.Models.Users
{
    public class RegisterViewModelInput
    {
        [Required(ErrorMessage = "The login field is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "The email field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password field is required")]
        public string Password { get; set; }
    }
}
