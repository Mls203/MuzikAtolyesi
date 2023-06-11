using FinalProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProje.Controllers
{
    public class KategoriMüzikBaglantiController : Controller
    {
        AletKategoriMuzikBaglanti model = new AletKategoriMuzikBaglanti();
        dropDownEntities db = new dropDownEntities();
        public ActionResult Menu()
        {
          List<AletKategori> KategoriList = db.AletKategori.OrderBy(f => f.kategoriadi).ToList();
           model.KategoriList = (from u in KategoriList
                                 select new SelectListItem
                                 {
                                    Text = u.kategoriadi,
                                    Value = u.kategoriId.ToString()

                                 }
                                 ).ToList();
            return View(model);
        }
       
        [HttpPost]
        public JsonResult GetAletList(int id)
        {
            List<Muzikler> AletList = db.Muzikler.Where(f => f.kategoriId == id).OrderBy(f => f.aletAdi).ToList();
            List<SelectListItem> itemlist = (from m in AletList
                                             select new SelectListItem
                                             {
                                                 Text = m.aletAdi,
                                                 Value = m.aletId.ToString()
                                             }).ToList();

            return Json(itemlist,JsonRequestBehavior.AllowGet);
        }

      
    }
}