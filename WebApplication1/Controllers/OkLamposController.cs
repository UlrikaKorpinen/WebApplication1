using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class OkLamposController : Controller
    {
        private WarehouseDBEntities db = new WarehouseDBEntities();

        // GET: OkLampos
        public ActionResult Index()
        {
            List<LampoViewModel> model = new List<LampoViewModel>();
            WarehouseDBEntities entities = new WarehouseDBEntities();

            try
            {
                List<OkLampo> lammot = entities.OkLampoes.ToList();
                foreach (OkLampo lampotila in lammot)
                {
                    LampoViewModel lampo = new LampoViewModel();
                    lampo.IdLampo = lampotila.IdLampo;
                    lampo.Huone = lampotila.Huone;
                    lampo.LampoKirjattu = lampotila.LampoKirjattu;
                    lampo.TavoiteLampo = lampotila.TavoiteLampo;
                    lampo.NykyLampo = lampotila.NykyLampo;
                    lampo.LampoOn = lampotila.LampoOn;
                    lampo.LampoOff = lampotila.LampoOff;

                    model.Add(lampo);
                
                }

}
            finally
            {
                entities.Dispose();
            }
            return View(model);
        }

        CultureInfo fiFi = new CultureInfo("fi-Fi");

        // GET: OkLampos/Details/5
        public ActionResult Details(int? id)
        {
            LampoViewModel model = new LampoViewModel();
            WarehouseDBEntities entities = new WarehouseDBEntities();

            try
            {
                OkLampo okLampoTila = db.OkLampoes.Find(id);
                if (okLampoTila == null)
                {
                    return HttpNotFound();
                }
                OkLampo lampodetail = entities.OkLampoes.Find(okLampoTila.IdLampo);
                LampoViewModel lampo = new LampoViewModel();
                lampo.IdLampo = lampodetail.IdLampo;
                lampo.Huone = lampodetail.Huone;
                lampo.LampoKirjattu = lampodetail.LampoKirjattu;
                lampo.TavoiteLampo = lampodetail.TavoiteLampo;
                lampo.NykyLampo = lampodetail.NykyLampo;
                model = lampo;

            }
            finally
            {
                entities.Dispose();
            }

            return View(model);

        }

        // GET: OkLampos/Create
        public ActionResult Create()
        {
            LampoViewModel model = new LampoViewModel();
            WarehouseDBEntities db = new WarehouseDBEntities();

            ViewBag.Huone = new SelectList((from ol in db.OkLampoes select new { IdLampo = ol.IdLampo, Huone = ol.Huone }), "IdLampo", "Huone", null);

            return View(model);

        }

        // POST: OkLampos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LampoViewModel model)
        {
            OkLampo lampo = new OkLampo();

            lampo.IdLampo = model.IdLampo;
            lampo.Huone = model.Huone;
            lampo.LampoKirjattu = model.LampoKirjattu;
            lampo.TavoiteLampo = model.TavoiteLampo;
            lampo.NykyLampo = model.NykyLampo;
            lampo.LampoOn = model.LampoOn;
            lampo.LampoOff = model.LampoOff;

            db.OkLampoes.Add(lampo);

            ViewBag.Huone = new SelectList((from ol in db.OkLampoes select new { IdLampo = ol.IdLampo, Huone = ol.Huone }), "IdLampo", "Huone", null);

            try
            { 
                db.SaveChanges();
                
            }

            catch(Exception ex)
            {

            }

            return RedirectToAction("Index");
        }

        // GET: OkLampos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkLampo lampotila = db.OkLampoes.Find(id);
            if (lampotila == null)
            {
                return HttpNotFound();
            }

            LampoViewModel lampo = new LampoViewModel();
            lampo.IdLampo = lampotila.IdLampo;
            lampo.Huone = lampotila.Huone;
            //lampo.LampoKirjattu = lampotila.LampoKirjattu;
            lampo.TavoiteLampo = lampotila.TavoiteLampo;
            lampo.NykyLampo = lampotila.NykyLampo;
            //lampo.LampoOn = lampotila.LampoOn;
            //lampo.LampoOff = lampotila.LampoOff;

            ViewBag.Huone = new SelectList((from ol in db.OkLampoes select new { IdLampo = ol.IdLampo, Huone = ol.Huone }), "IdLampo", "Huone", null);

            return View(lampo);
        }

        // POST: OkLampos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LampoViewModel model)
        {
            OkLampo lampo = db.OkLampoes.Find(model.IdLampo);

            lampo.IdLampo = model.IdLampo;
            lampo.Huone = model.Huone;
            lampo.LampoKirjattu = DateTime.Now;
            lampo.TavoiteLampo = model.TavoiteLampo;
            lampo.NykyLampo = model.NykyLampo;
            //lampo.LampoOn = model.LampoOn;
            //lampo.LampoOff = model.LampoOff;

            ViewBag.Huone = new SelectList((from ol in db.OkLampoes select new { IdLampo = ol.IdLampo, Huone = ol.Huone }), "IdLampo", "Huone", null);

            db.SaveChanges();

            return RedirectToAction("Index");
            }

        // GET: OkLampos/LampoOn/5
        public ActionResult LampoOn(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkLampo lampotila = db.OkLampoes.Find(id);
            if (lampotila == null)
            {
                return HttpNotFound();
            }

            LampoViewModel lampo = new LampoViewModel();
            lampo.IdLampo = lampotila.IdLampo;
            lampo.Huone = lampotila.Huone;
            //lampo.LampoKirjattu = lampotila.LampoKirjattu;
            //lampo.TavoiteLampo = lampotila.TavoiteLampo;
            //lampo.NykyLampo = lampotila.NykyLampo;
            lampo.LampoOn = true;
            lampo.LampoOff = false;


            ViewBag.Huone = new SelectList((from ol in db.OkLampoes select new { IdLampo = ol.IdLampo, Huone = ol.Huone }), "IdLampo", "Huone", null);

            return View(lampo);
        }

        // POST: OkLampos/LampoOn/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LampoOn(LampoViewModel model)
        {
            OkLampo lampo = db.OkLampoes.Find(model.IdLampo);

            lampo.IdLampo = model.IdLampo;
            lampo.Huone = model.Huone;
            lampo.LampoKirjattu = DateTime.Now;
            //lampo.TavoiteLampo = model.TavoiteLampo;
            //lampo.NykyLampo = model.NykyLampo;
            lampo.LampoOn = true;
            lampo.LampoOff = false;

            ViewBag.Huone = new SelectList((from ol in db.OkLampoes select new { IdLampo = ol.IdLampo, Huone = ol.Huone }), "IdLampo", "Huone", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: OkLampos/LampoOff/5
        public ActionResult LampoOff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkLampo lampotila = db.OkLampoes.Find(id);
            if (lampotila == null)
            {
                return HttpNotFound();
            }

            LampoViewModel lampo = new LampoViewModel();
            lampo.IdLampo = lampotila.IdLampo;
            lampo.Huone = lampotila.Huone;
            //lampo.LampoKirjattu = lampotila.LampoKirjattu;
            //lampo.TavoiteLampo = lampotila.TavoiteLampo;
            //lampo.NykyLampo = lampotila.NykyLampo;
            lampo.LampoOn = false;
            lampo.LampoOff = true;


            ViewBag.Huone = new SelectList((from ol in db.OkLampoes select new { IdLampo = ol.IdLampo, Huone = ol.Huone }), "IdLampo", "Huone", null);

            return View(lampo);
        }

        // POST: OkLampos/LampoOff/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LampoOff(LampoViewModel model)
        {
            OkLampo lampo = db.OkLampoes.Find(model.IdLampo);

            lampo.IdLampo = model.IdLampo;
            lampo.Huone = model.Huone;
            lampo.LampoKirjattu = DateTime.Now;
            //lampo.TavoiteLampo = model.TavoiteLampo;
            //lampo.NykyLampo = model.NykyLampo;
            lampo.LampoOn = false;
            lampo.LampoOff = true;

            ViewBag.Huone = new SelectList((from ol in db.OkLampoes select new { IdLampo = ol.IdLampo, Huone = ol.Huone }), "IdLampo", "Huone", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: OkLampos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkLampo lampotila = db.OkLampoes.Find(id);
            if (lampotila == null)
            {
                return HttpNotFound();
            }

            LampoViewModel lampo = new LampoViewModel();
            lampo.IdLampo = lampotila.IdLampo;
            lampo.Huone = lampotila.Huone;
            lampo.LampoKirjattu = lampotila.LampoKirjattu;
            lampo.TavoiteLampo = lampotila.TavoiteLampo;
            lampo.NykyLampo = lampotila.NykyLampo;
            lampo.LampoOn = lampotila.LampoOn;
            lampo.LampoOff = lampotila.LampoOff;

            return View(lampo);
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
