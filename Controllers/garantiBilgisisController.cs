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
    public class garantiBilgisisController : Controller
    {
        private MuzikAtolyesiEntities6 db = new MuzikAtolyesiEntities6();

        // GET: garantiBilgisis
        public ActionResult Index()
        {
            var garantiBilgisi = db.garantiBilgisi.Include(g => g.Muzik);
            return View(garantiBilgisi.ToList());
        }

        // GET: garantiBilgisis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            garantiBilgisi garantiBilgisi = db.garantiBilgisi.Find(id);
            if (garantiBilgisi == null)
            {
                return HttpNotFound();
            }
            return View(garantiBilgisi);
        }

        // GET: garantiBilgisis/Create
        public ActionResult Create()
        {
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi");
            return View();
        }

        // POST: garantiBilgisis/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "garantiId,aletId,garantiSüresi")] garantiBilgisi garantiBilgisi)
        {
            if (ModelState.IsValid)
            {
                db.garantiBilgisi.Add(garantiBilgisi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", garantiBilgisi.aletId);
            return View(garantiBilgisi);
        }

        // GET: garantiBilgisis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            garantiBilgisi garantiBilgisi = db.garantiBilgisi.Find(id);
            if (garantiBilgisi == null)
            {
                return HttpNotFound();
            }
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", garantiBilgisi.aletId);
            return View(garantiBilgisi);
        }

        // POST: garantiBilgisis/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "garantiId,aletId,garantiSüresi")] garantiBilgisi garantiBilgisi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garantiBilgisi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", garantiBilgisi.aletId);
            return View(garantiBilgisi);
        }

        // GET: garantiBilgisis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            garantiBilgisi garantiBilgisi = db.garantiBilgisi.Find(id);
            if (garantiBilgisi == null)
            {
                return HttpNotFound();
            }
            return View(garantiBilgisi);
        }

        // POST: garantiBilgisis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            garantiBilgisi garantiBilgisi = db.garantiBilgisi.Find(id);
            db.garantiBilgisi.Remove(garantiBilgisi);
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
    }
}
