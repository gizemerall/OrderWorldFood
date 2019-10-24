﻿using Microsoft.AspNet.Identity.EntityFramework;
using OrderWorldFood.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrderWorldFood.Entity
{
    public class DataContext:DbContext
    {
      public DataContext() : base("dataConnection")
        {
            //  Database.SetInitializer(new DataInitializer()); bunu burdan alıp global.asax içine koyduk
        }

        public DbSet<Product> Products { get; set; }
       
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

    }
}