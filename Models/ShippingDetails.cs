using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderWorldFood.Models
{
    //siparişle ilgili teslimat formu bilgileri

    public class ShippingDetails 
    {

        public string UserName { get; set; }

        [Required(ErrorMessage ="Please identify your adress")]
        public string AdressHead{ get; set; }

        [Required(ErrorMessage = "Please enter an adress")]
        public string Adress1 { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your distrinct")]
        public string Distrinct { get; set; }

        [Required(ErrorMessage = "Please enter your street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter your postalcode")]
        public string postalCode{ get; set; }








    }
}