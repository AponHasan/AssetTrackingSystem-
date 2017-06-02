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
    public class AssetPurchaseHeaderController : Controller
    {
        private AssetTrackDbContext db = new AssetTrackDbContext();
        private AssetPurchaseHeaderManager _assetPurchaseHeaderManager;
        private VendorManager _vendorManager;
        private OrganizationBranchManager _organizationBranchManager;

        public AssetPurchaseHeaderController()
        {
            _organizationBranchManager = new OrganizationBranchManager();
            _assetPurchaseHeaderManager = new AssetPurchaseHeaderManager();
            _vendorManager = new VendorManager();
        }

        // GET: /AssetPurchaseHeader/
        public ActionResult Index()
        {
            //var assetpurchaseheaders = db.AssetPurchaseHeaders.Include(a => a.OrganizationBranch);
            var assetpurchaseheaders = _assetPurchaseHeaderManager.GetAll();
            return View(assetpurchaseheaders.ToList());
        }

        // GET: /AssetPurchaseHeader/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseHeader assetpurchaseheader = _assetPurchaseHeaderManager.GetById((int) id);
            if (assetpurchaseheader == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchaseheader);
        }
        // GET: /AssetPurchaseHeader/Create
        public ActionResult Create()
        {
            var organizationBranches = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranches, "OrganizationBranchID", "OrganizationBranchName");
            var vendor = _vendorManager.GetAll();
            ViewBag.VendorID = new SelectList(vendor, "VendorID", "VendorName");
            return View();
        }

        // POST: /AssetPurchaseHeader/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AssetPurchaseHeaderID,VendorID,PurchasedOn,PurchasedBy,OrganizationBranchID,CreatedBy,CreatedOn,LastModifiedBy,LastModifiedOn")] AssetPurchaseHeader assetpurchaseheader)
        {
            if (ModelState.IsValid)
            {
                _assetPurchaseHeaderManager.Add(assetpurchaseheader);
                return RedirectToAction("Index");
            }

            var organizationBranches = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranches, "OrganizationBranchID", "OrganizationBranchName");
            var vendor = _vendorManager.GetAll();
            ViewBag.VendorID = new SelectList(vendor, "VendorID", "VendorName");
            return View(assetpurchaseheader);
        }

        // GET: /AssetPurchaseHeader/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseHeader assetpurchaseheader = _assetPurchaseHeaderManager.GetById((int) id);
            if (assetpurchaseheader == null)
            {
                return HttpNotFound();
            }
            var organizationBranches = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranches, "OrganizationBranchID", "OrganizationBranchName");
            var vendor = _vendorManager.GetAll();
            ViewBag.VendorID = new SelectList(vendor, "VendorID", "VendorName");
            return View(assetpurchaseheader);
        }

        // POST: /AssetPurchaseHeader/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AssetPurchaseHeaderID,VendorID,PurchasedOn,PurchasedBy,OrganizationBranchID,CreatedBy,CreatedOn,LastModifiedBy,LastModifiedOn")] AssetPurchaseHeader assetpurchaseheader)
        {
            if (ModelState.IsValid)
            {
                _assetPurchaseHeaderManager.Update(assetpurchaseheader);
                return RedirectToAction("Index");
            }
            var organizationBranches = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranches, "OrganizationBranchID", "OrganizationBranchName");
            var vendor = _vendorManager.GetAll();
            ViewBag.VendorID = new SelectList(vendor, "VendorID", "VendorName");
            return View(assetpurchaseheader);
        }

        // GET: /AssetPurchaseHeader/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseHeader assetpurchaseheader = _assetPurchaseHeaderManager.GetById((int) id);
            if (assetpurchaseheader == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchaseheader);
        }

        // POST: /AssetPurchaseHeader/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _assetPurchaseHeaderManager.Remove(id);
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
