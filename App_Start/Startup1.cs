using System;

using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(OrderWorldFood.App_Start.Startup1))]

namespace OrderWorldFood.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            //genel ayarların yapldıgı bir config dosyası

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {

                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login")

            });


        }
    }
}
