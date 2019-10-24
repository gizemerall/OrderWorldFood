using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using OrderWorldFood.Entity;
using OrderWorldFood.Identity;
using OrderWorldFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderWorldFood.Controllers
{
    public class AccountController:Controller //bütün login ve register işlemlerini yöneticek
    {

        private DataContext db = new DataContext();

        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);


            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;

            var orders = db.Orders.Where(i => i.UserName == username).Select(i => new UserOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate =i.OrderDate,
                OrderState=i.OrderState,
                Total=i.Total

            }).OrderByDescending(i=>i.OrderDate).ToList();
           

            return View(orders);
        }

        [Authorize]
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
                  ProductId=a.ProductId,
                  ProductName=a.Product.Name,
                  Image=a.Product.Image,
                  Quantity=a.Quantity,
                  price=a.price




                }).ToList()

            }).FirstOrDefault();

            return View(entity);
        }

        //boş register form u gelicek
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {

            if (ModelState.IsValid)
            {
                //kayıt işlemleri

                var user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //kullanıcı oluştu bir role atayabilirsiniz
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("Register user error", "error while creating user");

                }

            }

            return View(model);
        }



        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {

            if (ModelState.IsValid)
            {
                //login işlemleri

               var user = UserManager.Find(model.UserName, model.Password);

                if(user != null){

                    //varolan kullanıcıyı sisteme dahil et
                    //ApplicationCookie oluşturup sisteme bırak

                    //bunlar sürekli yapılan rutin işlemler

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties= new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties,identityclaims);

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("Login user error", "No user");

                }        

            }

            return View(model);
        }


        public ActionResult Logout() //oluşturduğum cookie yi sistemden siliyorum
        {
            var authManager = HttpContext.GetOwinContext().Authentication;

            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}