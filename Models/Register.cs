using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderWorldFood.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Surname")]
        public string SurName { get; set; }

        [Required]
        [DisplayName("UserName")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Email please")]
        [EmailAddress(ErrorMessage="Please correct your email adress.")]
        public string Email{ get; set; }

        [Required]
        [DisplayName("Enter your password")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Password Again")]
        [Compare("Password",ErrorMessage ="your passwords not matched!")]
        public string RePassword { get; set; }



    }
}