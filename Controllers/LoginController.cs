using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProje.Models;


namespace FinalProje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
       
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile userObj)
        {
            if (ModelState.IsValid)//modelin geçerli olup olmadığını kontrol ediyoruz
            { //bağlantıyı kuruyoruz
                using (MuzikAtolyesiEntities6 db = new MuzikAtolyesiEntities6())
                {
                    //userobj'den gelen bilgi UserProfile tablosundakine eşitmi kontrolü yapılır.
                    var obj = db.UserProfile.Where(a => a.UserName.Equals(userObj.UserName) && a.Password.Equals(userObj.Password)).FirstOrDefault();

                    //userObj nulldan farksız ise veri vardır ve sesion açacağız
                    if (obj != null)
                    {
                        Session["UserId"] = obj.UserId.ToString();
                        Session["Username"] = obj.UserName.ToString();
                        return RedirectToAction("AnaSayfa");

                    }

                }

            }
            return View(userObj);
        }

        public ActionResult AnaSayfa()
        {
            return View();
        }

    }
}