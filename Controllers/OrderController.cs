using OrderWorldFood.Entity;
using OrderWorldFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderWorldFood.Controllers
{
    [Authorize(Roles ="admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();

      public ActionResult Index()
        {

            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id=i.Id,
                OrderNumber=i.OrderNumber,
                OrderDate=i.OrderDate,
                OrderState=i.OrderState,
                Total=i.Total,
                Count=i.Orderlines.Count

            }).OrderByDescending(i=>i.OrderDate).ToList();

            return View(orders);
        }

        public ActionResult Details(int id)
        {

            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                AdressHead = i.AdressHead,
                Adress1 = i.Adress1,
                City = i.City,
                Distrinct = i.Distrinct,
                Street = i.Street,
                postalCode = i.postalCode,
                Orderlines = i.Orderlines.Select(a => new OrderLineModel()
                {
                    ProductId = a.ProductId,
                    ProductName = a.Product.Name,
                    Image = a.Product.Image,
                    Quantity = a.Quantity,
                    price = a.price




                }).ToList()

            }).FirstOrDefault();

            return View(entity);

        }
    }
}