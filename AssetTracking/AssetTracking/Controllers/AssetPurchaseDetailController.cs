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
    public class AssetPurchaseDetailController : Controller
    {
        private AssetTrackDbContext db = new AssetTrackDbContext();
        private AssetPurchaseDetailManager _assetPurchaseDetailManager;
        private WarrantyPeriodUnitManager _warrantyPeriodUnitManager;
        private CategoryManager _categoryManager;
        private OrganizationBranchManager _organizationBranchManager;


        public AssetPurchaseDetailController()
        {
            _warrantyPeriodUnitManager = new WarrantyPeriodUnitManager();
            _assetPurchaseDetailManager = new AssetPurchaseDetailManager();
            _categoryManager = new CategoryManager();
            _organizationBranchManager =new OrganizationBranchManager();
        }
        // GET: /AssetPurchase/
        public ActionResult Index()
        {

            return View(db.AssetPurchaseDetails.ToList());
        }

        // GET: /AssetPurchase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseDetail assetpurchasedetail = db.AssetPurchaseDetails.Find(id);
            if (assetpurchasedetail == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchasedetail);
        }

        // GET: /AssetPurchase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AssetPurchase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AssetPurchaseDetailID,VendorID,ProductCategoryID,WarrantyPeriodUnitID,OrganizationBranchID,Quantity,UnitPrice,IsWarranty,WarrantyPeriod,SerialNumber,PurchasedOn,PurchasedBy")] AssetPurchaseDetail assetpurchasedetail)
        {
            if (ModelState.IsValid)
            {
                db.AssetPurchaseDetails.Add(assetpurchasedetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assetpurchasedetail);
        }

        // GET: /AssetPurchase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseDetail assetpurchasedetail = db.AssetPurchaseDetails.Find(id);
            if (assetpurchasedetail == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchasedetail);
        }

        // POST: /AssetPurchase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AssetPurchaseDetailID,VendorID,ProductCategoryID,WarrantyPeriodUnitID,OrganizationBranchID,Quantity,UnitPrice,IsWarranty,WarrantyPeriod,SerialNumber,PurchasedOn,PurchasedBy")] AssetPurchaseDetail assetpurchasedetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assetpurchasedetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assetpurchasedetail);
        }

        // GET: /AssetPurchase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseDetail assetpurchasedetail = db.AssetPurchaseDetails.Find(id);
            if (assetpurchasedetail == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchasedetail);
        }

        // POST: /AssetPurchase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetPurchaseDetail assetpurchasedetail = db.AssetPurchaseDetails.Find(id);
            db.AssetPurchaseDetails.Remove(assetpurchasedetail);
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
