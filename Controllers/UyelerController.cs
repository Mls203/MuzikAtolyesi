using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProje.Models;
using System.Linq.Dynamic.Core;


namespace FinalProje.Controllers
{
    public class UyelerController : Controller
    {
        // GET: Uyeler
        public ActionResult Index(string sort ="UyeAdi",string sortdir = "asc",string search = "")

        {
            int totalRecord = 0;
            var data = GetUyeler(search, sort, sortdir, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;
            return View(data);
        }

        public List<Uyeler> GetUyeler(string search, string sort, string sortdir, out int totalRecord)

        {
            //burada AlbümEntities veritabanı içeriğini oluşturmaktadır
            using (MuzikAtolyesiEntities6 db = new MuzikAtolyesiEntities6())
            {
                var v = (from a in db.Uyeler

                         where a.UyeAdi .Contains(search) ||
                         a.UyeSoyadi.Contains(search) ||
                         a.UyeTc.Contains(search)||
                         a.UyeAdres.Contains(search) 
                         select a
                );

                totalRecord = v.Count();
                v = v.OrderBy(sort + " " + sortdir);
                return v.ToList();
            }
        }



    
       

       
    }
}