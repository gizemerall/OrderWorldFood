using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OrderWorldFood.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Product Description")]
        public string Description { get; set; }
        public bool Available { get; set; }
        public bool IsApproved { get; set; }
        public double Price { get; set; }

        public string Image { get; set; }
        public int CategoryId { get; set; } //foreign key
        public Category Category { get; set; }
    }
}