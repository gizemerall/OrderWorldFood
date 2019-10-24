using OrderWorldFood.Entity;
using OrderWorldFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderWorldFood.Controllers
{
    public class CartController : Controller
    {

        private DataContext db = new DataContext(); //ürün veritabanında var mı kontrol edicem asağda o yuzden ekledım

        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int Id) //sepete eklemek için tıkladıgım eleman var mı ? varsa ekle
        {

            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCart().AddProduct(product,1);
            }


            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id) //sepetten silme
        {

            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }


            return RedirectToAction("Index");
        }

        public Cart GetCart() //kişiye özel cart olmak zorunda..session içine atıcam..herseferinde yeni cart yollamıcam session içindekini yollucam
        {
            //session her kullanıcıya özel depo.Cart bir kere oluşunca orda saklanıcak.sitemi 100 kişi ziyaret ettiyse 100 tane session var demektir
            //kimse diğerlerinin kartında ne var goremez

            var cart = (Cart)Session["Cart"];

            if(cart == null)
            {

                cart = new Cart();

                Session["Cart"] = cart;

            }

            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }



        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {

            var cart = GetCart();

            if (cart.Cartlines.Count ==0)
            {
                ModelState.AddModelError("No food error", "You dont have any food in your shopping cart");

            }
            if(ModelState.IsValid)
            {
                //siparişi veritabanına kayıt et.
                //cart ı sıfırla 

                SaveOrder(cart,entity);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }

            return View();
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();

            order.OrderNumber = "A"+(new Random()).Next(111111,999999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Waiting;
            order.UserName = User.Identity.Name;


           
            order.AdressHead = entity.AdressHead;
            order.Adress1 = entity.Adress1;
            order.City = entity.City;
            order.Street = entity.Street;
            order.postalCode = entity.postalCode;

            order.Orderlines = new List<OrderLine>();

            foreach (var pr in cart.Cartlines)
            {

                var orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.price = pr.Quantity * pr.Product.Price;
                orderline.ProductId = pr.Product.Id;

                order.Orderlines.Add(orderline);


            }
            db.Orders.Add(order);
            db.SaveChanges();

        }
    }
}