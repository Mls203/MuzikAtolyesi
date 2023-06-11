using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FinalProje
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Sesion_start(object sender, EventArgs e)
        {
            int onlineUyeSayisi = Convert.ToInt32(Application["OnlineUyeSayisi"]);
            onlineUyeSayisi = onlineUyeSayisi + 1;
            //online uye sayýsýný güncelliyorum
            Application["OnlineUyeSayisi"] = onlineUyeSayisi;

        }
        protected void Sesion_End(object sender, EventArgs e)
        {

            int onlineUyeSayisi = Convert.ToInt32(Application["OnlineUyeSayisi"]);
            //oturum kapandýðýnda bir kullanýcý eksilmiþ olacak
            onlineUyeSayisi = onlineUyeSayisi - 1;
            //online uye sayýsýný güncelliyorum
            Application["OnlineUyeSayisi"] = onlineUyeSayisi;

        }





    }
}
