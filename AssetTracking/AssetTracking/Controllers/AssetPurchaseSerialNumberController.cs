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
    public class AssetPurchaseSerialNumberController : Controller
    {
        private AssetTrackDbContext db = new AssetTrackDbContext();
        private AssetPurchaseSerialNumberManager _assetPurchaseSerialNumberManager;
        private AssetPurchaseDetailManager _assetPurchaseDetailManager;


        public AssetPurchaseSerialNumberController()
        {
            _assetPurchaseDetailManager = new AssetPurchaseDetailManager();
            _assetPurchaseSerialNumberManager = new AssetPurchaseSerialNumberManager();
        }
        // GET: /AssetPurchaseSerialNumber/
        public ActionResult Index()
        {
            //var assetPurchaseSerialNumberManager = _assetPurchaseSerialNumberManager.GetAll();
            //return View(assetPurchaseSerialNumberManager.ToList());
            return View(db.AssetPurchaseDetailSerialNumbers.ToList());
        }

        // GET: /AssetPurchaseSerialNumber/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //AssetPurchaseDetailSerialNumber assetpurchasedetailserialnumber = _assetPurchaseSerialNumberManager.GetById((int)id);

            AssetPurchaseDetailSerialNumber assetpurchasedetailserialnumber = db.AssetPurchaseDetailSerialNumbers.Find(id);
            if (assetpurchasedetailserialnumber == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchasedetailserialnumber);
        }

        // GET: /AssetPurchaseSerialNumber/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AssetPurchaseSerialNumber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AssetPurchaseDetailSerialNumberID,PerchaseDetailID,SerialNumber")] AssetPurchaseDetailSerialNumber assetpurchasedetailserialnumber)
        {
            if (ModelState.IsValid)
            {
                db.AssetPurchaseDetailSerialNumbers.Add(assetpurchasedetailserialnumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assetpurchasedetailserialnumber);
        }

        // GET: /AssetPurchaseSerialNumber/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseDetailSerialNumber assetpurchasedetailserialnumber = db.AssetPurchaseDetailSerialNumbers.Find(id);
            if (assetpurchasedetailserialnumber == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchasedetailserialnumber);
        }

        // POST: /AssetPurchaseSerialNumber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AssetPurchaseDetailSerialNumberID,PerchaseDetailID,SerialNumber")] AssetPurchaseDetailSerialNumber assetpurchasedetailserialnumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assetpurchasedetailserialnumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assetpurchasedetailserialnumber);
        }

        // GET: /AssetPurchaseSerialNumber/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseDetailSerialNumber assetpurchasedetailserialnumber = db.AssetPurchaseDetailSerialNumbers.Find(id);
            if (assetpurchasedetailserialnumber == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchasedetailserialnumber);
        }

        // POST: /AssetPurchaseSerialNumber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetPurchaseDetailSerialNumber assetpurchasedetailserialnumber = db.AssetPurchaseDetailSerialNumbers.Find(id);
            db.AssetPurchaseDetailSerialNumbers.Remove(assetpurchasedetailserialnumber);
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
