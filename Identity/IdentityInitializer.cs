using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OrderWorldFood.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrderWorldFood.Identity
{
    public class IdentityInitializer:CreateDatabaseIfNotExists<IdentityDataContext>
    {

        protected override void Seed(IdentityDataContext context)
        {

            //roles
            if(!context.Roles.Any(i =>i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole(){ Name = "admin", Description = "admin role" };
                manager.Create(role);

            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name="user",Description="user role"};
                manager.Create(role);

            }


            //user

            if (!context.Roles.Any(i => i.Name == "gizemmeral"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "gizem", Surname = "meral", UserName = "gizemmeral", Email = "gizemcanmeral1@gmail.com" };
                


                manager.Create(user,"1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");


            }

            if (!context.Roles.Any(i => i.Name == "sunpreetsingh"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "sunpreet", Surname = "singh", UserName = "sunpreetsingh", Email = "sunpreetsingh@gmail.com" };



                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");
            }

            base.Seed(context);
        }
    }
}