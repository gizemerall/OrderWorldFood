using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OrderWorldFood.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            var kategoriler = new List<Category>()
            {
              new Category(){Name="Turkish",Description="TurkishFoods",Id=1},
              new Category(){Name="Indian",Description="IndianFoods",Id=2},
              new Category(){Name="Italian",Description="ItalianFoods",Id=3},
              new Category(){Name="Korean",Description="KoreanaFoods",Id=4}
            };


            foreach(var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();


            var urunler = new List<Product>()
            {
              new Product(){Name="Karnıyarık",Description="eggplant",Price=34 ,Available=true ,IsApproved=true,CategoryId=1,Image="1.jpg"},
              new Product(){Name="Pilav",Description="turkish rice",Price=45 ,Available=true,IsApproved=true,CategoryId=1,Image="2.jpg"},
              new Product(){Name="KuruFasulye",Description="traditional",Price=13 ,Available=false ,IsApproved=false,CategoryId=1,Image="3.jpg"},
              new Product(){Name="Sarma",Description="the best",Price=78 ,Available= true,IsApproved=false,CategoryId=1,Image="4.jpg"},
              new Product(){Name="Mercimek Çorbası",Description="classical",Price=13 ,Available=true ,IsApproved=true,CategoryId=1,Image="5.jpg"},


              new Product(){Name="Butter Chicken",Description="non vegetarian",Price=12,Available=true,IsApproved=true,CategoryId=2,Image="1.jpg"},
              new Product(){Name="Samosas",Description="pastary",Price=56 ,Available=false,IsApproved=false,CategoryId=2,Image="3.jpg"},
              new Product(){Name="Malai Kofta",Description="tarditional",Price=45 ,Available=true,IsApproved=true,CategoryId=2,Image="2.jpg"},
              new Product(){Name="Matar Paneer",Description="cheese",Price= 89,Available=false,IsApproved=true,CategoryId=2,Image="4.jpg"},
              new Product(){Name="Rogan Josh",Description="classical indian food",Price=100 ,Available=false,IsApproved=true,CategoryId=2,Image="5.jpg"},


              new Product(){Name="Spagetti",Description="macaroni",Price=34 ,Available=true,IsApproved=true,CategoryId=3,Image="5.jpg"},
              new Product(){Name="Pizza",Description="pastry",Price=12 ,Available=true,IsApproved=false,CategoryId=3,Image="1.jpg"},
              new Product(){Name="Tiramisu",Description="kind of dessert",Price=45 ,Available=false,IsApproved=true,CategoryId=3,Image="4.jpg"},
              new Product(){Name="Con burro",Description="dessert",Price= 78,Available=false,IsApproved=true,CategoryId=3,Image="3.jpg"},
              new Product(){Name="Lasagna",Description="kind of macaroni",Price=10 ,Available=true,IsApproved=false,CategoryId=3,Image="2.jpg"},


              new Product(){Name="Kimchi",Description="fashion food",Price=25 ,Available=true,IsApproved=true,CategoryId=4,Image="1.jpg"},
              new Product(){Name="Japchae",Description="traditional",Price=78 ,Available=false,IsApproved=true,CategoryId=4,Image="5.jpg"},
              new Product(){Name="Hoeddeok",Description="kind of shoup",Price=12 ,Available=false,IsApproved=false,CategoryId=4,Image="4.jpg"},
              new Product(){Name="Bulgogi",Description="kind of main food",Price=90 ,Available=true,IsApproved=false,CategoryId=4,Image="3.jpg"},
              new Product(){Name="Bibimbap",Description="Kind of pastry eat with sauce",Price=15 ,Available=true,IsApproved=true,CategoryId=4,Image="2.jpg"},

            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();

            base.Seed(context);
        }

    }
}