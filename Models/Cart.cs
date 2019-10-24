using OrderWorldFood.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderWorldFood.Models
{
    public class Cart //alışveriş sepetinin tamamı
    {
        private List<CartLine> cartlines = new List<CartLine>(); //sınıfa özel liste,alışveriş sepetimi oluşturuyor temel kısım

        public List<CartLine> Cartlines //private olan cartlines a ulaşmak için public olanı yaptık
        {

            get { return cartlines; }
        }

        public void AddProduct(Product product,int quantity)
        {

            var line = cartlines.FirstOrDefault(i => i.Product.Id == product.Id);
            //ürün daha önce varsa gene ekleme ama sayısını arttır,eger yoksa ekle
            if (line==null) //yoksa ekledim
            {
                cartlines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }

        }
          
        public void DeleteProduct(Product product)
        {
            cartlines.RemoveAll(i => i.Product.Id == product.Id);
        }

        public double Total()
        {
            return cartlines.Sum(i => i.Product.Price * i.Quantity);
        }

        public void Clear()
        {
            cartlines.Clear(); //sepeti boşalt linki
        }
    }

    public class CartLine //herbir ürünü temsil eden obje
    { 
        //bunu bir satır gibi düşün ürün bilgieleri ve en sonda kaçtane olduğu
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

}