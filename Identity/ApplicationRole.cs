using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderWorldFood.Identity
{
    public class ApplicationRole:IdentityRole
    {

        public string Description { get; set; } //açıklama örneğin admin rolüne kim kullanıcı rolüne kim sahip olabilir gibi


        public ApplicationRole()
        {

        }


        //application tole tanımlarken direk rol ismi ve descrption direk verebilicez
        public ApplicationRole(string rolename,string description)
        {
            this.Description = description;
        }



    }
}