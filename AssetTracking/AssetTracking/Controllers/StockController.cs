using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetTracking.Models.Models;
using AssetTracking.Models.Database;

namespace AssetTracking.Controllers
{
    public class StockController : Controller
    {
        private AssetTrackDbContext db = new AssetTrackDbContext();

        // GET: /Stock/
        public ActionResult Index()
        {
            var assetpurchaseheaders = db.AssetPurchaseHeaders.Include(a => a.OrganizationBranch).Include(a => a.Vendor);
            return View(assetpurchaseheaders.ToList());
        }

        // GET: /Stock/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseHeader assetpurchaseheader = db.AssetPurchaseHeaders.Find(id);
            if (assetpurchaseheader == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchaseheader);
        }

        // GET: /Stock/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationBranchID = new SelectList(db.OrganizationBranches, "OrganizationBranchID", "OrganizationBranchName");
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "VendorName");
            return View();
        }

        // POST: /Stock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AssetPurchaseHeaderID,VendorID,PurchasedOn,OrganizationBranchID")] AssetPurchaseHeader assetpurchaseheader)
        {
            if (ModelState.IsValid)
            {
                db.AssetPurchaseHeaders.Add(assetpurchaseheader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationBranchID = new SelectList(db.OrganizationBranches, "OrganizationBranchID", "OrganizationBranchName", assetpurchaseheader.OrganizationBranchID);
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "VendorName", assetpurchaseheader.VendorID);
            return View(assetpurchaseheader);
        }

        // GET: /Stock/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseHeader assetpurchaseheader = db.AssetPurchaseHeaders.Find(id);
            if (assetpurchaseheader == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationBranchID = new SelectList(db.OrganizationBranches, "OrganizationBranchID", "OrganizationBranchName", assetpurchaseheader.OrganizationBranchID);
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "VendorName", assetpurchaseheader.VendorID);
            return View(assetpurchaseheader);
        }

        // POST: /Stock/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AssetPurchaseHeaderID,VendorID,PurchasedOn,OrganizationBranchID")] AssetPurchaseHeader assetpurchaseheader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assetpurchaseheader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationBranchID = new SelectList(db.OrganizationBranches, "OrganizationBranchID", "OrganizationBranchName", assetpurchaseheader.OrganizationBranchID);
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "VendorName", assetpurchaseheader.VendorID);
            return View(assetpurchaseheader);
        }

        // GET: /Stock/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseHeader assetpurchaseheader = db.AssetPurchaseHeaders.Find(id);
            if (assetpurchaseheader == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchaseheader);
        }

        // POST: /Stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetPurchaseHeader assetpurchaseheader = db.AssetPurchaseHeaders.Find(id);
            db.AssetPurchaseHeaders.Remove(assetpurchaseheader);
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
