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
    public class StokTakipsController : Controller
    {
        private MuzikAtolyesiEntities6 db = new MuzikAtolyesiEntities6();

        // GET: StokTakips
        public ActionResult Index()
        {
            var stokTakip = db.StokTakip.Include(s => s.Muzik);
            return View(stokTakip.ToList());
        }

        // GET: StokTakips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StokTakip stokTakip = db.StokTakip.Find(id);
            if (stokTakip == null)
            {
                return HttpNotFound();
            }
            return View(stokTakip);
        }

        // GET: StokTakips/Create
        public ActionResult Create()
        {
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi");
            return View();
        }

        // POST: StokTakips/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stokId,stokAdeti,aletId")] StokTakip stokTakip)
        {
            if (ModelState.IsValid)
            {
                db.StokTakip.Add(stokTakip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", stokTakip.aletId);
            return View(stokTakip);
        }

        // GET: StokTakips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StokTakip stokTakip = db.StokTakip.Find(id);
            if (stokTakip == null)
            {
                return HttpNotFound();
            }
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", stokTakip.aletId);
            return View(stokTakip);
        }

        // POST: StokTakips/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stokId,stokAdeti,aletId")] StokTakip stokTakip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stokTakip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aletId = new SelectList(db.Muzik, "aletId", "aletAdi", stokTakip.aletId);
            return View(stokTakip);
        }

        // GET: StokTakips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StokTakip stokTakip = db.StokTakip.Find(id);
            if (stokTakip == null)
            {
                return HttpNotFound();
            }
            return View(stokTakip);
        }

        // POST: StokTakips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StokTakip stokTakip = db.StokTakip.Find(id);
            db.StokTakip.Remove(stokTakip);
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
