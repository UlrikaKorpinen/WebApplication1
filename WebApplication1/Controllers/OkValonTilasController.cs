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
    public class OkValonTilasController : Controller
    {
        private WarehouseDBEntities db = new WarehouseDBEntities();

        // GET: OkValonTilas
        public ActionResult Index()
        {
            List<ValoViewModel> model = new List<ValoViewModel>();
            WarehouseDBEntities entities = new WarehouseDBEntities();

            try
            {
                List<OkValonTila> valot = entities.OkValonTilas.ToList();

                foreach (OkValonTila okvalo in valot)
                {
                    ValoViewModel valo = new ValoViewModel();

                    valo.IdValonTila = okvalo.IdValonTila;
                    valo.HuoneNimi = okvalo.HuoneNimi;
                    valo.ValaisinNimi = okvalo.ValaisinNimi;
                    valo.ValotOn33 = okvalo.ValotOn33;
                    valo.Valot33 = okvalo.Valot33;
                    valo.ValotOn66 = okvalo.ValotOn66;
                    valo.Valot66 = okvalo.Valot66;
                    valo.ValotOn100 = okvalo.ValotOn100;
                    valo.Valot100 = okvalo.Valot100;
                    valo.ValotOff = okvalo.ValotOff;
                    valo.ValonTilaOff = okvalo.ValonTilaOff;

                    model.Add(valo);
                }
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }

        CultureInfo fiFi = new CultureInfo("fi-FI");

        // GET: OkValonTilas/Details/5
        public ActionResult Details(int? id)
        {
            ValoViewModel model = new ValoViewModel();
            WarehouseDBEntities entities = new WarehouseDBEntities();

            try
            {
                OkValonTila okValoTila = db.OkValonTilas.Find(id);
                if (okValoTila == null)
                {
                    return HttpNotFound();
                }
                OkValonTila valodetail = entities.OkValonTilas.Find(okValoTila.IdValonTila);
                ValoViewModel valo = new ValoViewModel();
                valo.IdValonTila = valodetail.IdValonTila;
                valo.HuoneNimi = valodetail.HuoneNimi;
                valo.ValaisinNimi = valodetail.ValaisinNimi;
                valo.ValotOn33 = valodetail.ValotOn33;
                valo.Valot33 = valodetail.Valot33;
                valo.ValotOn66 = valodetail.ValotOn66;
                valo.Valot66 = valodetail.Valot66;
                valo.ValotOn100 = valodetail.ValotOn100;
                valo.Valot100 = valodetail.Valot100;
                valo.ValotOff = valodetail.ValotOff;
                valo.ValonTilaOff = valodetail.ValonTilaOff;
                model = valo;
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);

        }

        // GET: OkValonTilas/Create
        public ActionResult Create()
        {
            ValoViewModel model = new ValoViewModel();
            WarehouseDBEntities entities = new WarehouseDBEntities();

            ViewBag.HuoneNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, HuoneNimi = ov.HuoneNimi }), "IdValonTila", "HuoneNimi", null);
            ViewBag.ValaisinNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, ValaisinNimi = ov.ValaisinNimi }), "IdValonTila", "ValaisinNimi", null);
            return View(model);
        }

        // POST: OkValonTilas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ValoViewModel model)
        {
            OkValonTila valo = new OkValonTila();

            valo.IdValonTila = model.IdValonTila;
            valo.HuoneNimi = model.HuoneNimi;
            valo.ValaisinNimi = model.ValaisinNimi;
            valo.ValotOn33 = model.ValotOn33;
            valo.Valot33 = model.Valot33;
            valo.ValotOn66 = model.ValotOn66;
            valo.Valot66 = model.Valot66;
            valo.ValotOn100 = model.ValotOn100;
            valo.Valot100 = model.Valot100;
            valo.ValotOff = model.ValotOff;
            valo.ValonTilaOff = model.ValonTilaOff;

            db.OkValonTilas.Add(valo);

            ViewBag.HuoneNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, HuoneNimi = ov.HuoneNimi }), "IdValonTila", "HuoneNimi", null);
            ViewBag.ValaisinNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, ValaisinNimi = ov.ValaisinNimi }), "IdValonTila", "ValaisinNimi", null);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {

            }

            return RedirectToAction("Index");

        }

        // GET: OkValonTilas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkValonTila valotila = db.OkValonTilas.Find(id);
            if (valotila == null)
            {
                return HttpNotFound();
            }

            ValoViewModel valo = new ValoViewModel();

            valo.IdValonTila = valotila.IdValonTila;
            valo.HuoneNimi = valotila.HuoneNimi;
            valo.ValaisinNimi = valotila.ValaisinNimi;
            valo.ValotOn33 = valotila.ValotOn33;
            valo.Valot33 = valotila.Valot33;
            valo.ValotOn66 = valotila.ValotOn66;
            valo.Valot66 = valotila.Valot66;
            valo.ValotOn100 = valotila.ValotOn100;
            valo.Valot100 = valotila.Valot100;
            valo.ValotOff = valotila.ValotOff;
            valo.ValonTilaOff = valotila.ValonTilaOff;

            ViewBag.HuoneNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, HuoneNimi = ov.HuoneNimi }), "IdValonTila", "HuoneNimi", null);
            ViewBag.ValaisinNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, ValaisinNimi = ov.ValaisinNimi }), "IdValonTila", "ValaisinNimi", null);

            return View(valo);
        }



        // POST: OkValonTilas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ValoViewModel model)
        {
            OkValonTila valo = db.OkValonTilas.Find(model.IdValonTila);

            valo.IdValonTila = model.IdValonTila;
            valo.HuoneNimi = model.HuoneNimi;
            valo.ValaisinNimi = model.ValaisinNimi;
            valo.ValotOn33 = model.ValotOn33;
            valo.Valot33 = model.Valot33;
            valo.ValotOn66 = model.ValotOn66;
            valo.Valot66 = model.Valot66;
            valo.ValotOn100 = model.ValotOn100;
            valo.Valot100 = model.Valot100;
            valo.ValotOff = model.ValotOff;
            valo.ValonTilaOff = model.ValonTilaOff;

            ViewBag.HuoneNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, HuoneNimi = ov.HuoneNimi }), "IdValonTila", "HuoneNimi", null);
            ViewBag.ValaisinNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, ValaisinNimi = ov.ValaisinNimi }), "IdValonTila", "ValaisinNimi", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: OkValonTilas/ValotOn33/5
        public ActionResult ValotOn33(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkValonTila valotila = db.OkValonTilas.Find(id);
            if (valotila == null)
            {
                return HttpNotFound();
            }

            ValoViewModel valo = new ValoViewModel();

            valo.IdValonTila = valotila.IdValonTila;
            valo.HuoneNimi = valotila.HuoneNimi;
            valo.ValaisinNimi = valotila.ValaisinNimi;
            valo.ValotOn33 = DateTime.Now;
            valo.Valot33 = true;
            //valo.ValotOn66 = DateTime.Now;
            valo.Valot66 = false;
            //valo.ValotOn100 = valotila.ValotOn100;
            valo.Valot100 = false;
            //valo.ValotOff = DateTime.Now;
            valo.ValonTilaOff = false;

            ViewBag.HuoneNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, HuoneNimi = ov.HuoneNimi }), "IdValonTila", "HuoneNimi", null);
            ViewBag.ValaisinNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, ValaisinNimi = ov.ValaisinNimi }), "IdValonTila", "ValaisinNimi", null);

            return View(valo);
        }



        // POST: OkValonTilas/ValotOn33/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValotOn33(ValoViewModel model)
        {
            OkValonTila valo = db.OkValonTilas.Find(model.IdValonTila);

            //valo.IdValonTila = model.IdValonTila;
            valo.HuoneNimi = model.HuoneNimi;
            valo.ValaisinNimi = model.ValaisinNimi;
            valo.ValotOn33 = DateTime.Now;
            valo.Valot33 = true;
            //valo.ValotOn66 = DateTime.Now;
            valo.Valot66 = false;
            //valo.ValotOn100 = DateTime.Now;
            valo.Valot100 = false;
            //valo.ValotOff = DateTime.Now;
            valo.ValonTilaOff = false;

            ViewBag.HuoneNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, HuoneNimi = ov.HuoneNimi }), "IdValonTila", "HuoneNimi", null);
            ViewBag.ValaisinNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, ValaisinNimi = ov.ValaisinNimi }), "IdValonTila", "ValaisinNimi", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: OkValonTilas/ValotOn66/5
        public ActionResult ValotOn66(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkValonTila valotila = db.OkValonTilas.Find(id);
            if (valotila == null)
            {
                return HttpNotFound();
            }

            ValoViewModel valo = new ValoViewModel();

            valo.IdValonTila = valotila.IdValonTila;
            valo.HuoneNimi = valotila.HuoneNimi;
            valo.ValaisinNimi = valotila.ValaisinNimi;
            //valo.ValotOn33 = DateTime.Now;
            valo.Valot33 = false;
            valo.ValotOn66 = DateTime.Now;
            valo.Valot66 = true;
            //valo.ValotOn100 = valotila.ValotOn100;
            valo.Valot100 = false;
            //valo.ValotOff = DateTime.Now;
            valo.ValonTilaOff = false;

            ViewBag.HuoneNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, HuoneNimi = ov.HuoneNimi }), "IdValonTila", "HuoneNimi", null);
            ViewBag.ValaisinNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, ValaisinNimi = ov.ValaisinNimi }), "IdValonTila", "ValaisinNimi", null);

            return View(valo);
        }



        // POST: OkValonTilas/ValotOn66/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValotOn66(ValoViewModel model)
        {
            OkValonTila valo = db.OkValonTilas.Find(model.IdValonTila);

            //valo.IdValonTila = model.IdValonTila;
            valo.HuoneNimi = model.HuoneNimi;
            valo.ValaisinNimi = model.ValaisinNimi;
            //valo.ValotOn33 = DateTime.Now;
            valo.Valot33 = false;
            valo.ValotOn66 = DateTime.Now;
            valo.Valot66 = true;
            //valo.ValotOn100 = DateTime.Now;
            valo.Valot100 = false;
            //valo.ValotOff = DateTime.Now;
            valo.ValonTilaOff = false;

            ViewBag.HuoneNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, HuoneNimi = ov.HuoneNimi }), "IdValonTila", "HuoneNimi", null);
            ViewBag.ValaisinNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, ValaisinNimi = ov.ValaisinNimi }), "IdValonTila", "ValaisinNimi", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: OkValonTilas/ValotOn100
        public ActionResult ValotOn100(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkValonTila valotila = db.OkValonTilas.Find(id);
            if (valotila == null)
            {
                return HttpNotFound();
            }

            ValoViewModel valo = new ValoViewModel();

            valo.IdValonTila = valotila.IdValonTila;
            valo.HuoneNimi = valotila.HuoneNimi;
            valo.ValaisinNimi = valotila.ValaisinNimi;
            //valo.ValotOn33 = DateTime.Now;
            valo.Valot33 = false;
            //valo.ValotOn66 = DateTime.Now;
            valo.Valot66 = false;
            valo.ValotOn100 = valotila.ValotOn100;
            valo.Valot100 = true;
            //valo.ValotOff = DateTime.Now;
            valo.ValonTilaOff = false;

            ViewBag.HuoneNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, HuoneNimi = ov.HuoneNimi }), "IdValonTila", "HuoneNimi", null);
            ViewBag.ValaisinNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, ValaisinNimi = ov.ValaisinNimi }), "IdValonTila", "ValaisinNimi", null);

            return View(valo);
        }



        // POST: OkValonTilas/ValotOn100/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValotOn100(ValoViewModel model)
        {
            OkValonTila valo = db.OkValonTilas.Find(model.IdValonTila);

            //valo.IdValonTila = model.IdValonTila;
            valo.HuoneNimi = model.HuoneNimi;
            valo.ValaisinNimi = model.ValaisinNimi;
            //valo.ValotOn33 = DateTime.Now;
            valo.Valot33 = false;
            //valo.ValotOn66 = DateTime.Now;
            valo.Valot66 = false;
            valo.ValotOn100 = DateTime.Now;
            valo.Valot100 = true;
            //valo.ValotOff = DateTime.Now;
            valo.ValonTilaOff = false;

            ViewBag.HuoneNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, HuoneNimi = ov.HuoneNimi }), "IdValonTila", "HuoneNimi", null);
            ViewBag.ValaisinNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, ValaisinNimi = ov.ValaisinNimi }), "IdValonTila", "ValaisinNimi", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: OkValonTilas/ValotOff/5
        public ActionResult ValotOff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkValonTila valotila = db.OkValonTilas.Find(id);
            if (valotila == null)
            {
                return HttpNotFound();
            }

            ValoViewModel valo = new ValoViewModel();

            valo.IdValonTila = valotila.IdValonTila;
            valo.HuoneNimi = valotila.HuoneNimi;
            valo.ValaisinNimi = valotila.ValaisinNimi;
            //valo.ValotOn33 = DateTime.Now;
            valo.Valot33 = false;
            //valo.ValotOn66 = DateTime.Now;
            valo.Valot66 = false;
            //valo.ValotOn100 = DateTime.Now;
            valo.Valot100 = false;
            valo.ValotOff = DateTime.Now;
            valo.ValonTilaOff = true;

            ViewBag.HuoneNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, HuoneNimi = ov.HuoneNimi }), "IdValonTila", "HuoneNimi", null);
            ViewBag.ValaisinNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, ValaisinNimi = ov.ValaisinNimi }), "IdValonTila", "ValaisinNimi", null);

            return View(valo);
        }



        // POST: OkValonTilas/ValotOff/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValotOff(ValoViewModel model)
        {
            OkValonTila valo = db.OkValonTilas.Find(model.IdValonTila);

            valo.IdValonTila = model.IdValonTila;
            valo.HuoneNimi = model.HuoneNimi;
            valo.ValaisinNimi = model.ValaisinNimi;
            //valo.ValotOn33 = DateTime.Now;
            valo.Valot33 = false;
            //valo.ValotOn66 = DateTime.Now;
            valo.Valot66 = false;
            //valo.ValotOn100 = DateTime.Now;
            valo.Valot100 = false;
            valo.ValotOff = DateTime.Now;
            valo.ValonTilaOff = true;

            ViewBag.HuoneNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, HuoneNimi = ov.HuoneNimi }), "IdValonTila", "HuoneNimi", null);
            ViewBag.ValaisinNimi = new SelectList((from ov in db.OkValonTilas select new { IdValonTila = ov.IdValonTila, ValaisinNimi = ov.ValaisinNimi }), "IdValonTila", "ValaisinNimi", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: OkValonTilas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkValonTila valotila = db.OkValonTilas.Find(id);
            if (valotila == null)
            {
                return HttpNotFound();
            }

            ValoViewModel valo = new ValoViewModel();
            valo.IdValonTila = valotila.IdValonTila;
            valo.HuoneNimi = valotila.HuoneNimi;
            valo.ValaisinNimi = valotila.ValaisinNimi;
            valo.ValotOn33 = valotila.ValotOn33;
            valo.Valot33 = valotila.Valot33;
            valo.ValotOn66 = valotila.ValotOn66;
            valo.Valot66 = valotila.Valot66;
            valo.ValotOn100 = valotila.ValotOn100;
            valo.Valot100 = valotila.Valot100;
            valo.ValotOff = valotila.ValotOff;
            valo.ValonTilaOff = valotila.ValonTilaOff;

            return View(valo);
        }

        // POST: OkValonTilas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OkValonTila okValonTila = db.OkValonTilas.Find(id);
            db.OkValonTilas.Remove(okValonTila);
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
