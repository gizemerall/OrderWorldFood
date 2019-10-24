using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderWorldFood.Models
{
    public class ProductModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Available { get; set; }
        public double Price { get; set; }

        public string Image { get; set; }
        public int CategoryId { get; set; } //foreign key
    }
}