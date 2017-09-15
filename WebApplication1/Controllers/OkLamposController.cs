using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OkLamposController : Controller
    {
        private WarehouseDBEntities db = new WarehouseDBEntities();

        // GET: OkLampos
        public ActionResult Index()
        {
            return View(db.OkLampoes.ToList());
        }

        // GET: OkLampos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkLampo okLampo = db.OkLampoes.Find(id);
            if (okLampo == null)
            {
                return HttpNotFound();
            }
            return View(okLampo);
        }

        // GET: OkLampos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OkLampos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLampo,LampoKirjattu,Huone,TavoiteLampo,NykyLampo")] OkLampo okLampo)
        {
            if (ModelState.IsValid)
            {
                db.OkLampoes.Add(okLampo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(okLampo);
        }

        // GET: OkLampos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkLampo okLampo = db.OkLampoes.Find(id);
            if (okLampo == null)
            {
                return HttpNotFound();
            }
            return View(okLampo);
        }

        // POST: OkLampos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLampo,LampoKirjattu,Huone,TavoiteLampo,NykyLampo")] OkLampo okLampo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(okLampo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(okLampo);
        }

        // GET: OkLampos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkLampo okLampo = db.OkLampoes.Find(id);
            if (okLampo == null)
            {
                return HttpNotFound();
            }
            return View(okLampo);
        }

        // POST: OkLampos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OkLampo okLampo = db.OkLampoes.Find(id);
            db.OkLampoes.Remove(okLampo);
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
