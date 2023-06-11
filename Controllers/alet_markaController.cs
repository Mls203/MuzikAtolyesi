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
    public class alet_markaController : Controller
    {
        private MuzikAtolyesiEntities6 db = new MuzikAtolyesiEntities6();

        // GET: alet_marka
        public ActionResult Index()
        {
            var alet_marka = db.alet_marka.Include(a => a.Muzik);
            return View(alet_marka.ToList());
        }

        // GET: alet_marka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alet_marka alet_marka = db.alet_marka.Find(id);
            if (alet_marka == null)
            {
                return HttpNotFound();
            }
            return View(alet_marka);
        }

        // GET: alet_marka/Create
        public ActionResult Create()
        {
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi");
            return View();
        }

        // POST: alet_marka/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "markaId,aletId,markaAdi")] alet_marka alet_marka)
        {
            if (ModelState.IsValid)
            {
                db.alet_marka.Add(alet_marka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", alet_marka.aletId);
            return View(alet_marka);
        }

        // GET: alet_marka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alet_marka alet_marka = db.alet_marka.Find(id);
            if (alet_marka == null)
            {
                return HttpNotFound();
            }
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", alet_marka.aletId);
            return View(alet_marka);
        }

        // POST: alet_marka/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "markaId,aletId,markaAdi")] alet_marka alet_marka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alet_marka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", alet_marka.aletId);
            return View(alet_marka);
        }

        // GET: alet_marka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alet_marka alet_marka = db.alet_marka.Find(id);
            if (alet_marka == null)
            {
                return HttpNotFound();
            }
            return View(alet_marka);
        }

        // POST: alet_marka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            alet_marka alet_marka = db.alet_marka.Find(id);
            db.alet_marka.Remove(alet_marka);
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
