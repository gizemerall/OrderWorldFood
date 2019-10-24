using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderWorldFood.Identity
{
    public class ApplicationUser:IdentityUser // temel sınıfım, identity user içinde id ve isim var onu kullanıcaz,ekstra gerekirse application user içine ekleyebiliriz
    {
      
        public string Name { get; set; }
        public string Surname { get; set; }


    }
}