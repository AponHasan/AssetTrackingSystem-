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
        private SubCategoryManager _subCategoryManager;
        private AssetPurchaseHeaderManager _assetPurchaseHeaderManager;
        private WarrantyPeriodUnitManager _warrantyPeriodUnitManager;

        public AssetPurchaseDetailController()
        {
            _subCategoryManager = new SubCategoryManager();
            _assetPurchaseHeaderManager = new AssetPurchaseHeaderManager();
            _warrantyPeriodUnitManager = new WarrantyPeriodUnitManager();
            _assetPurchaseDetailManager = new AssetPurchaseDetailManager();
        }

        // GET: /AssetPurchaseDetail/
        public ActionResult Index()
        {
            //var assetpurchasedetails = db.AssetPurchaseDetails.Include(a => a.AssetPurchaseHeader).Include(a => a.SubCategory);
            var assetpurchasedetails = _assetPurchaseDetailManager.GetAll();
            return View(assetpurchasedetails.ToList());
        }

        // GET: /AssetPurchaseDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseDetail assetpurchasedetail = _assetPurchaseDetailManager.GetById((int)id);
            if (assetpurchasedetail == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchasedetail);
        }

        // GET: /AssetPurchaseDetail/Create
        public ActionResult Create()
        {
            //ViewBag.AssetPurchaseHeaderID = new SelectList(db.AssetPurchaseHeaders, "AssetPurchaseHeaderID", "AssetPurchaseHeaderID");
            //ViewBag.SubCategoryID = new SelectList(db.SubCategories, "SubCategoryID", "SubCategoryName");
            var assetPurchaseHeader = _assetPurchaseHeaderManager.GetAll();
            ViewBag.AssetPurchaseHeaderID = new SelectList(assetPurchaseHeader, "AssetPurchaseHeaderID", "AssetPurchaseHeaderID");
            var subCategories = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategories, "SubCategoryID", "SubCategoryName");
            var warrantyPeriodID = _warrantyPeriodUnitManager.GetAll();
            ViewBag.WarrantyPeriodUnitID = new SelectList(warrantyPeriodID, "WarrantyPeriodUnitID", "WarrantyPeriodUnitName");
            return View();
        }

        // POST: /AssetPurchaseDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AssetPurchaseDetailID,AssetPurchaseHeaderID,SubCategoryID,Quantity,UnitPrice,IsWarranty,WarrantyPeriod,WarrantyPeriodUnitID")] AssetPurchaseDetail assetpurchasedetail)
        {
            if (ModelState.IsValid)
            {
                _assetPurchaseDetailManager.Add(assetpurchasedetail);
                return RedirectToAction("Index");
            }

            var assetPurchaseHeader = _assetPurchaseHeaderManager.GetAll();
            ViewBag.AssetPurchaseHeaderID = new SelectList(assetPurchaseHeader, "AssetPurchaseHeaderID", "AssetPurchaseHeaderID");
            var subCategories = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategories, "SubCategoryID", "SubCategoryName");
            var warrantyPeriodID = _warrantyPeriodUnitManager.GetAll();
            ViewBag.WarrantyPeriodUnitID = new SelectList(warrantyPeriodID, "WarrantyPeriodUnitID", "WarrantyPeriodUnitName");
            return View(assetpurchasedetail);
        }

        // GET: /AssetPurchaseDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseDetail assetpurchasedetail = _assetPurchaseDetailManager.GetById((int) id);
            if (assetpurchasedetail == null)
            {
                return HttpNotFound();
            }
            var assetPurchaseHeader = _assetPurchaseHeaderManager.GetAll();
            ViewBag.AssetPurchaseHeaderID = new SelectList(assetPurchaseHeader, "AssetPurchaseHeaderID", "AssetPurchaseHeaderID");
            var subCategories = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategories, "SubCategoryID", "SubCategoryName");
            var warrantyPeriodID = _warrantyPeriodUnitManager.GetAll();
            ViewBag.WarrantyPeriodUnitID = new SelectList(warrantyPeriodID, "WarrantyPeriodUnitID", "WarrantyPeriodUnitName");
            return View(assetpurchasedetail);
        }

        // POST: /AssetPurchaseDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AssetPurchaseDetailID,AssetPurchaseHeaderID,SubCategoryID,Quantity,UnitPrice,IsWarranty,WarrantyPeriod,WarrantyPeriodUnitID")] AssetPurchaseDetail assetpurchasedetail)
        {
            if (ModelState.IsValid)
            {
                _assetPurchaseDetailManager.Update(assetpurchasedetail);
                return RedirectToAction("Index");
            }
            var assetPurchaseHeader = _assetPurchaseHeaderManager.GetAll();
            ViewBag.AssetPurchaseHeaderID = new SelectList(assetPurchaseHeader, "AssetPurchaseHeaderID", "AssetPurchaseHeaderID");
            var subCategories = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategories, "SubCategoryID", "SubCategoryName");
            var warrantyPeriodID = _warrantyPeriodUnitManager.GetAll();
            ViewBag.WarrantyPeriodUnitID = new SelectList(warrantyPeriodID, "WarrantyPeriodUnitID", "WarrantyPeriodUnitName");
            return View(assetpurchasedetail);
        }

        // GET: /AssetPurchaseDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseDetail assetpurchasedetail = _assetPurchaseDetailManager.GetById((int) id);
            if (assetpurchasedetail == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchasedetail);
        }

        // POST: /AssetPurchaseDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //AssetPurchaseDetail assetpurchasedetail = db.AssetPurchaseDetails.Find(id);
            //db.AssetPurchaseDetails.Remove(assetpurchasedetail);
            //db.SaveChanges();
            _assetPurchaseDetailManager.Remove(id);
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
