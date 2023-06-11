using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProje.Controllers
{
    public class CerezController : Controller
    {
        // GET: Cerez
        public ActionResult OnlineUyeSayisi()
        {
            ViewBag.OnlineUyeSayisi = HttpContext.Application["OnlineUyeSayisi"];
            return View();
        }
        //cookie oluşturuyorum
        public ActionResult Olustur()
        {
            HttpCookie cookieKullanici = new HttpCookie("kullanıcı","melisa");
            HttpContext.Response.Cookies.Add(cookieKullanici);
            ViewBag.kullanıcı = HttpContext.Request.Cookies["kullanıcı"].Value;
            return View();
        }
        //oluşturduğum cookie siliyorum
        public ActionResult Sil()
        {
            
            HttpContext.Request.Cookies.Remove("kullanıcı");
           
            return View();
        }

    }
}