using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderWorldFood.Identity
{
    public class IdentityDataContext:IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("dataConnection")
        {
           
          //identity için farklı veritabanı kullanmak istersen baska bir veritabanı bağlantısı ekleyebilirz.ben aynı connection kullandık


        }


    }
}