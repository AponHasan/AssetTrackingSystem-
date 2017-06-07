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
    public class StockController : Controller
    {
        private AssetTrackDbContext db = new AssetTrackDbContext();
        private StockManager _stockManager;
        private SubCategoryManager _subCategoryManager;
        private CategoryManager _categoryManager;
        private GeneralCategoryManager _generalCategoryManager;
        private ProductManager _productManager;
        private OrganizationBranchManager _organizationBranchManager;
        private VendorManager _vendorManager;


        public StockController()
        {
            _stockManager = new StockManager();
            _productManager = new ProductManager();
            _subCategoryManager = new SubCategoryManager();
            _categoryManager = new CategoryManager();
            _generalCategoryManager = new GeneralCategoryManager();
            _organizationBranchManager = new OrganizationBranchManager();
            _vendorManager = new VendorManager();
        }
        // GET: /Stock/
        public ActionResult Index()
        {
            var assetpurchaseheaders = _stockManager.GetAll();
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
            var generalCategoryList = _generalCategoryManager.GetAll();
            ViewBag.generalCategoryID = new SelectList(generalCategoryList, "GeneralCategoryID", "GeneralCategoryName");

            var categoryList = _categoryManager.GetAll();
            ViewBag.CategoryID = new SelectList(categoryList, "CategoryID", "CategoryName");

            var subCategoryList = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategoryList, "SubCategoryID", "SubCategoryName");

            var organizationBranchesList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchesList, "OrganizationBranchID", "OrganizationBranchName");

            var vendorList = _vendorManager.GetAll();
            ViewBag.VendorID = new SelectList(vendorList, "VendorID", "VendorName");
            return View();
        }

        // POST: /Stock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( AssetPurchaseHeader assetpurchaseheader)
        {
            if (ModelState.IsValid)
            {
                bool isCreate = _stockManager.Add(assetpurchaseheader);
              if(isCreate)
              {
                  ViewBag.Message = "Save All";
              }
                
               
            }
            var generalCategoryList = _generalCategoryManager.GetAll();
            ViewBag.generalCategoryID = new SelectList(generalCategoryList, "GeneralCategoryID", "GeneralCategoryName",null);

            var categoryList = _categoryManager.GetAll();
            ViewBag.CategoryID = new SelectList(categoryList, "CategoryID", "CategoryName",null);

            var subCategoryList = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategoryList, "SubCategoryID", "SubCategoryName",null);

            var organizationBranchesList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchesList, "OrganizationBranchID", "OrganizationBranchName",null);

            var vendorList = _vendorManager.GetAll();
            ViewBag.VendorID = new SelectList(vendorList, "VendorID", "VendorName",null);

            return View(assetpurchaseheader);
        }

        // GET: /Stock/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseHeader assetpurchaseheader = _stockManager.GetById((int) id);
            if (assetpurchaseheader == null)
            {
                return HttpNotFound();
            }
            var generalCategoryList = _generalCategoryManager.GetAll();
            ViewBag.generalCategoryID = new SelectList(generalCategoryList, "GeneralCategoryID", "GeneralCategoryName");

            var categoryList = _categoryManager.GetAll();
            ViewBag.CategoryID = new SelectList(categoryList, "CategoryID", "CategoryName");

            var subCategoryList = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategoryList, "SubCategoryID", "SubCategoryName");

            var organizationBranchesList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchesList, "OrganizationBranchID", "OrganizationBranchName");

            var vendorList = _vendorManager.GetAll();
            ViewBag.VendorID = new SelectList(vendorList, "VendorID", "VendorName");
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
