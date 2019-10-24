using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderWorldFood.Models
{
    public class Login
    {

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Enter your password")]
        public string Password { get; set; }


        [DisplayName("Remember Me")]
        public bool RememberMe{ get; set; }



    }
}