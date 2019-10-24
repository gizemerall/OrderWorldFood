using OrderWorldFood.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderWorldFood.Controllers
{
    public class HomeController : Controller
    {

        DataContext context = new DataContext();


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TurkishList()
        {
            return View(context.Products.Where(i => i.CategoryId == 1).ToList());
        }

        public ActionResult IndianList()
        {
            return View(context.Products.Where(i => i.CategoryId == 2).ToList());
        }
        public ActionResult ItalianList()
        {
            return View(context.Products.Where(i => i.CategoryId == 3).ToList());
        }

        public ActionResult KoreanList()
        {
            return View(context.Products.Where(i => i.CategoryId == 4).ToList());
        }
        public ActionResult TurkishDetail(int id)
        {
            return View(context.Products.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult IndianDetail(int id)
        {
            return View(context.Products.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult ItalianDetail(int id)
        {
            return View(context.Products.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult KoreanDetail(int id)
        {
            return View(context.Products.Where(i => i.Id == id).FirstOrDefault());
        }

    }

}