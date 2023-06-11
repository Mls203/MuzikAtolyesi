using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProje.Models;

namespace FinalProje.Controllers
{
    public class MuziksController : Controller
    {
        private MuzikAtolyesiEntities6 db = new MuzikAtolyesiEntities6();

        // GET: Muziks
        public ActionResult Index()
        {
            var muzik = db.Muzik.Include(m => m.alet_kategori).Include(m => m.alet_marka1).Include(m => m.garantiBilgisi1);
            return View(muzik.ToList());
        }

        // GET: Muziks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muzik muzik = db.Muzik.Find(id);
            if (muzik == null)
            {
                return HttpNotFound();
            }
            return View(muzik);
        }

        // GET: Muziks/Create
        public ActionResult Create()
        {
            ViewBag.kategoriId = new SelectList(db.alet_kategori, "kategoriId", "kategoriAdi");
            ViewBag.markaId = new SelectList(db.alet_marka, "markaId", "markaAdi");
            ViewBag.garantiId = new SelectList(db.garantiBilgisi, "garantiId", "garantiSüresi");
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi");
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi");
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi");
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi");
            return View();
        }

        // POST: Muziks/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aletId,kategoriId,aletAdi,satışAdetSayisi,aletFiyati,garantiId,stokId,markaId")] Muzik muzik)
        {
            if (ModelState.IsValid)
            {
                db.Muzik.Add(muzik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kategoriId = new SelectList(db.alet_kategori, "kategoriId", "kategoriAdi", muzik.kategoriId);
            ViewBag.markaId = new SelectList(db.alet_marka, "markaId", "markaAdi", muzik.markaId);
            ViewBag.garantiId = new SelectList(db.garantiBilgisi, "garantiId", "garantiSüresi", muzik.garantiId);
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", muzik.aletId);
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", muzik.aletId);
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", muzik.aletId);
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", muzik.aletId);
            return View(muzik);
        }

        // GET: Muziks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muzik muzik = db.Muzik.Find(id);
            if (muzik == null)
            {
                return HttpNotFound();
            }
            ViewBag.kategoriId = new SelectList(db.alet_kategori, "kategoriId", "kategoriAdi", muzik.kategoriId);
            ViewBag.markaId = new SelectList(db.alet_marka, "markaId", "markaAdi", muzik.markaId);
            ViewBag.garantiId = new SelectList(db.garantiBilgisi, "garantiId", "garantiSüresi", muzik.garantiId);
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", muzik.aletId);
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", muzik.aletId);
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", muzik.aletId);
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", muzik.aletId);
            return View(muzik);
        }

        // POST: Muziks/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aletId,kategoriId,aletAdi,satışAdetSayisi,aletFiyati,garantiId,stokId,markaId")] Muzik muzik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(muzik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kategoriId = new SelectList(db.alet_kategori, "kategoriId", "kategoriAdi", muzik.kategoriId);
            ViewBag.markaId = new SelectList(db.alet_marka, "markaId", "markaAdi", muzik.markaId);
            ViewBag.garantiId = new SelectList(db.garantiBilgisi, "garantiId", "garantiSüresi", muzik.garantiId);
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", muzik.aletId);
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", muzik.aletId);
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", muzik.aletId);
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", muzik.aletId);
            return View(muzik);
        }

        // GET: Muziks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muzik muzik = db.Muzik.Find(id);
            if (muzik == null)
            {
                return HttpNotFound();
            }
            return View(muzik);
        }

        // POST: Muziks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Muzik muzik = db.Muzik.Find(id);
            db.Muzik.Remove(muzik);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

          //linq sorguları id bilgisine göre
        public ActionResult AletKategori(int id)
        {
          
            string kategoriismi = (from k in db.alet_kategori
                                       where k.kategoriId == id
                                       select k.kategoriAdi).FirstOrDefault();
             
            ViewBag.Title = kategoriismi +"'ın"+ " "+ "listesi";
             ViewBag.Id = id;
            
                List<Muzik> filtre = (from m in db.Muzik
                                                where m.kategoriId == id
                                                select m).ToList();

            return View(filtre);
        }

    }


}
