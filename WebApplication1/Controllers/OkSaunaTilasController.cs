using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using System.Globalization;

namespace WebApplication1.Controllers
{
    public class OkSaunaTilasController : Controller
    {
        private WarehouseDBEntities db = new WarehouseDBEntities();

        // GET: OkSaunaTilas
        public ActionResult Index()
        {
            List<SaunaViewModel> model = new List<SaunaViewModel>();
            WarehouseDBEntities entities = new WarehouseDBEntities();

            try
            {
                List<OkSaunaTila> saunatilat = entities.OkSaunaTilas.ToList();
                foreach (OkSaunaTila saunatila in saunatilat)
                {
                    SaunaViewModel sauna = new SaunaViewModel();
                    sauna.IdSaunanTila = saunatila.IdSaunanTila;
                    sauna.SaunanNimi = saunatila.SaunanNimi;
                    sauna.SaunaOn = saunatila.SaunaOn;
                    sauna.SaunaOff = saunatila.SaunaOff;
                    sauna.SaunanTila = saunatila.SaunanTila;
                    sauna.SaunaTavoitelampo = saunatila.SaunaTavoitelampo;
                    sauna.SaunaNykylampo = saunatila.SaunaNykylampo;
                    sauna.TilaKirjattu = saunatila.TilaKirjattu;

                    model.Add(sauna);

                }
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);
        }

        CultureInfo fiFi = new CultureInfo("fi-Fi");


        // GET: OkSaunaTilas/Details/5
        public ActionResult Details(int? id)
        {
            SaunaViewModel model = new SaunaViewModel();
            WarehouseDBEntities entities = new WarehouseDBEntities();

            try
            {
                OkSaunaTila okSaunaTila = db.OkSaunaTilas.Find(id);
                if (okSaunaTila == null)
                {
                    return HttpNotFound();
                }
                OkSaunaTila saunadetail = entities.OkSaunaTilas.Find(okSaunaTila.IdSaunanTila);
                SaunaViewModel sauna = new SaunaViewModel();
                sauna.IdSaunanTila = saunadetail.IdSaunanTila;
                sauna.SaunanNimi = saunadetail.SaunanNimi;
                sauna.SaunanTila = saunadetail.SaunanTila;
                sauna.SaunaTavoitelampo = saunadetail.SaunaTavoitelampo;
                sauna.SaunaNykylampo = saunadetail.SaunaNykylampo;
                sauna.TilaKirjattu = saunadetail.TilaKirjattu;
                model = sauna;
            }
            finally
            {
                entities.Dispose();
            }

                return View(model);
        }

        // GET: OkSaunaTilas/Create
        public ActionResult Create()
        
        {
            SaunaViewModel model = new SaunaViewModel();
            WarehouseDBEntities db = new WarehouseDBEntities();

            ViewBag.SaunanNimi = new SelectList((from os in db.OkSaunaTilas select new { IdSaunanTila = os.IdSaunanTila, SaunanNimi = os.SaunanNimi }), "IdSaunanTila", "SaunanNimi", null);

            return View(model);
        }

        // POST: OkSaunaTilas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaunaViewModel model)
        {
            OkSaunaTila sauna = new OkSaunaTila();

            sauna.SaunanNimi = model.SaunanNimi;
            sauna.SaunanTila = model.SaunanTila;
            sauna.SaunaTavoitelampo = model.SaunaTavoitelampo;
            sauna.SaunaNykylampo = model.SaunaNykylampo;
            sauna.TilaKirjattu = model.TilaKirjattu;

            db.OkSaunaTilas.Add(sauna);

            ViewBag.SaunanNimi = new SelectList((from os in db.OkSaunaTilas select new { IdSaunanTila = os.IdSaunanTila, SaunanNimi = os.SaunanNimi }), "IdSaunanTila", "SaunanNimi", null);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {

            }

            return RedirectToAction("Index");

        }

        // GET: OkSaunaTilas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkSaunaTila saunatila = db.OkSaunaTilas.Find(id);
            if (saunatila == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.IdSaunanTila = saunatila.IdSaunanTila;
            sauna.SaunanNimi = saunatila.SaunanNimi;
            sauna.SaunaOn = saunatila.SaunaOn;
            sauna.SaunaOff = saunatila.SaunaOff;
            sauna.SaunanTila = saunatila.SaunanTila;
            sauna.SaunaTavoitelampo = saunatila.SaunaTavoitelampo;
            sauna.SaunaNykylampo = saunatila.SaunaNykylampo;
            sauna.TilaKirjattu = saunatila.TilaKirjattu;

            ViewBag.SaunanNimi = new SelectList((from os in db.OkSaunaTilas select new { IdSaunanTila = os.IdSaunanTila, SaunanNimi = os.SaunanNimi }), "IdSaunanTila", "SaunanNimi", null);

            return View(sauna);
        }

        // POST: OkSaunaTilas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaunaViewModel model)
        {
            OkSaunaTila sauna = db.OkSaunaTilas.Find(model.IdSaunanTila);

            sauna.SaunanNimi = model.SaunanNimi;
            sauna.SaunanTila = model.SaunanTila;
            sauna.SaunaTavoitelampo = model.SaunaTavoitelampo;
            sauna.SaunaNykylampo = model.SaunaNykylampo;
            sauna.TilaKirjattu = model.TilaKirjattu;

            ViewBag.SaunanNimi = new SelectList((from os in db.OkSaunaTilas select new { IdSaunanTila = os.IdSaunanTila, SaunanNimi = os.SaunanNimi }), "IdSaunanTila", "SaunanNimi", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: OkSaunaTila/SaunaOn/5
        public ActionResult SaunaOn(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkSaunaTila taloSauna = db.OkSaunaTilas.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.IdSaunanTila = taloSauna.IdSaunanTila;
            sauna.SaunanNimi = taloSauna.SaunanNimi;
            sauna.SaunaOn = taloSauna.SaunaOn;
            sauna.SaunanTila = taloSauna.SaunanTila;
            sauna.TilaKirjattu = taloSauna.TilaKirjattu;

            sauna.SaunanTila = true;

            ViewBag.SaunanNimi = new SelectList((from ts in db.OkSaunaTilas select new { IdSaunanTila = ts.IdSaunanTila, SaunanNimi = ts.SaunanNimi }), "IdSaunanTila", "SaunanNimi", sauna.IdSaunanTila);

            return View(sauna);
        }

        // POST: OkSaunaTila/SaunaOn/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaunaOn(SaunaViewModel model)
        {
            OkSaunaTila sauna = db.OkSaunaTilas.Find(model.IdSaunanTila);
            sauna.SaunanNimi = model.SaunanNimi;
            sauna.SaunanTila = model.SaunanTila;
            sauna.TilaKirjattu = model.TilaKirjattu;
            sauna.SaunaOn = DateTime.Now;
            sauna.SaunanTila = true;

            ViewBag.SaunanNimi = new SelectList((from ts in db.OkSaunaTilas select new { IdSaunanTila = ts.IdSaunanTila, SaunanNimi = ts.SaunanNimi }), "IdSaunanTila", "SaunanNimi", sauna.IdSaunanTila);

            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: OkSaunaTila/SaunaOff/5
        public ActionResult SaunaOff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkSaunaTila taloSauna = db.OkSaunaTilas.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.IdSaunanTila = taloSauna.IdSaunanTila;
            sauna.SaunanNimi = taloSauna.SaunanNimi;
            sauna.SaunaOff = taloSauna.SaunaOff;
            sauna.SaunanTila = taloSauna.SaunanTila;
            sauna.TilaKirjattu = taloSauna.TilaKirjattu;

            ViewBag.SaunanNimi = new SelectList((from ts in db.OkSaunaTilas select new { IdSaunanTila = ts.IdSaunanTila, SaunanNimi = ts.SaunanNimi }), "IdSaunanTila", "SaunanNimi", sauna.IdSaunanTila);

            return View(sauna);
        }

        // POST: OkSaunaTila/SaunaOff/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaunaOff(SaunaViewModel model)
        {
            OkSaunaTila sauna = db.OkSaunaTilas.Find(model.IdSaunanTila);
            sauna.SaunanNimi = model.SaunanNimi;
            sauna.SaunanTila = model.SaunanTila;
            sauna.TilaKirjattu = model.TilaKirjattu;
            sauna.SaunaOff= DateTime.Now;
            sauna.SaunanTila = false;

            ViewBag.SaunanNimi = new SelectList((from ts in db.OkSaunaTilas select new { IdSaunanTila = ts.IdSaunanTila, SaunanNimi = ts.SaunanNimi }), "IdSaunanTila", "SaunanNimi", sauna.IdSaunanTila);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: OkSaunaTilas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkSaunaTila saunatila = db.OkSaunaTilas.Find(id);
            if (saunatila == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.SaunanNimi = saunatila.SaunanNimi;
            sauna.SaunanTila = saunatila.SaunanTila;
            sauna.SaunaTavoitelampo = saunatila.SaunaTavoitelampo;
            sauna.SaunaNykylampo = saunatila.SaunaNykylampo;
            sauna.TilaKirjattu = saunatila.TilaKirjattu;

            return View(sauna);
        }

        // POST: OkSaunaTilas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OkSaunaTila okSaunaTila = db.OkSaunaTilas.Find(id);
            db.OkSaunaTilas.Remove(okSaunaTila);
            db.SaveChangesAsync();
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
