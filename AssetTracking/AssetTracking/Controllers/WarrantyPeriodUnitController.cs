using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetTracking.BLL;
using AssetTracking.Models.Models;
using AssetTracking.Models.Database;

namespace AssetTracking.Controllers
{
    public class WarrantyPeriodUnitController : Controller
    {
        private AssetTrackDbContext db = new AssetTrackDbContext();

        private WarrantyPeriodUnitManager _warrantyPeriodUnitManager;

        public WarrantyPeriodUnitController()
        {
            _warrantyPeriodUnitManager = new WarrantyPeriodUnitManager();
        }
        // GET: /WarrantyPeriodUnit/
        public ActionResult Index()
        {
            var warrantyPeriodUnits = _warrantyPeriodUnitManager.GetAll();
            return View(warrantyPeriodUnits.ToList());
        }

        // GET: /WarrantyPeriodUnit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarrantyPeriodUnit warrantyperiodunit = _warrantyPeriodUnitManager.GetById((int) id);
            if (warrantyperiodunit == null)
            {
                return HttpNotFound();
            }
            return View(warrantyperiodunit);
        }

        // GET: /WarrantyPeriodUnit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /WarrantyPeriodUnit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="WarrantyPeriodUnitID,WarrantyPeriodUnitName")] WarrantyPeriodUnit warrantyperiodunit)
        {
            if (ModelState.IsValid)
            {
                //db.WarrantyPeriodUnits.Add(warrantyperiodunit);
                //db.SaveChanges();
                _warrantyPeriodUnitManager.Add(warrantyperiodunit);
                return RedirectToAction("Index");
            }

            return View(warrantyperiodunit);
        }

        // GET: /WarrantyPeriodUnit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarrantyPeriodUnit warrantyperiodunit = _warrantyPeriodUnitManager.GetById((int) id);
            if (warrantyperiodunit == null)
            {
                return HttpNotFound();
            }
            return View(warrantyperiodunit);
        }

        // POST: /WarrantyPeriodUnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="WarrantyPeriodUnitID,WarrantyPeriodUnitName")] WarrantyPeriodUnit warrantyperiodunit)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(warrantyperiodunit).State = EntityState.Modified;
                //db.SaveChanges();
                _warrantyPeriodUnitManager.Update(warrantyperiodunit);
                return RedirectToAction("Index");
            }
            return View(warrantyperiodunit);
        }

        // GET: /WarrantyPeriodUnit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarrantyPeriodUnit warrantyperiodunit = _warrantyPeriodUnitManager.GetById((int) id);
            if (warrantyperiodunit == null)
            {
                return HttpNotFound();
            }
            return View(warrantyperiodunit);
        }

        // POST: /WarrantyPeriodUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //WarrantyPeriodUnit warrantyperiodunit = db.WarrantyPeriodUnits.Find(id);
            //db.WarrantyPeriodUnits.Remove(warrantyperiodunit);
            //db.SaveChanges();
            _warrantyPeriodUnitManager.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
