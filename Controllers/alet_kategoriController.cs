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
    public class alet_kategoriController : Controller
    {
        private MuzikAtolyesiEntities6 db = new MuzikAtolyesiEntities6();

        // GET: alet_kategori
        public ActionResult Index()
        {
            return View(db.alet_kategori.ToList());
        }

        // GET: alet_kategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alet_kategori alet_kategori = db.alet_kategori.Find(id);
            if (alet_kategori == null)
            {
                return HttpNotFound();
            }
            return View(alet_kategori);
        }

        // GET: alet_kategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: alet_kategori/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kategoriId,kategoriAdi")] alet_kategori alet_kategori)
        {
            if (ModelState.IsValid)
            {
                db.alet_kategori.Add(alet_kategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alet_kategori);
        }

        // GET: alet_kategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alet_kategori alet_kategori = db.alet_kategori.Find(id);
            if (alet_kategori == null)
            {
                return HttpNotFound();
            }
            return View(alet_kategori);
        }

        // POST: alet_kategori/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kategoriId,kategoriAdi")] alet_kategori alet_kategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alet_kategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alet_kategori);
        }

        // GET: alet_kategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alet_kategori alet_kategori = db.alet_kategori.Find(id);
            if (alet_kategori == null)
            {
                return HttpNotFound();
            }
            return View(alet_kategori);
        }

        // POST: alet_kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            alet_kategori alet_kategori = db.alet_kategori.Find(id);
            db.alet_kategori.Remove(alet_kategori);
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
