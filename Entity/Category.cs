using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderWorldFood.Entity
{
    public class Category
    {

        public int Id { get; set; } // primary key
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}