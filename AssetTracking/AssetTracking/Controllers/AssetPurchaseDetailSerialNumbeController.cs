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
using AssetTracking.Models.Interfaces.IModelManager;

namespace AssetTracking.Controllers
{
    public class AssetPurchaseDetailSerialNumbeController : Controller
    {
        private AssetTrackDbContext db = new AssetTrackDbContext();
        private IAssetPurchaseDetailSerialNumberManager _assetPurchaseDetailSerialNumberManager;
        private IAssetPurchaseDetailManager _assetPurchaseDetailManager;


        public AssetPurchaseDetailSerialNumbeController()
        {
            _assetPurchaseDetailManager = new AssetPurchaseDetailManager();
            _assetPurchaseDetailSerialNumberManager = new AssetPurchaseDetailSerialNumberManager();
        }
        // GET: /AssetPurchaseDetailSerialNumbe/
        public ActionResult Index()
        {
            return View(_assetPurchaseDetailSerialNumberManager.GetAll());
        }

        // GET: /AssetPurchaseDetailSerialNumbe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseDetailSerialNumber assetpurchasedetailserialnumber =
                _assetPurchaseDetailSerialNumberManager.GetById((int) id);
            if (assetpurchasedetailserialnumber == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchasedetailserialnumber);
        }

        // GET: /AssetPurchaseDetailSerialNumbe/Create
        public ActionResult Create()
        {
            var assetPurchaseDetailID = _assetPurchaseDetailManager.GetAll();
            ViewBag.PerchaseDetailID = new SelectList(assetPurchaseDetailID, "PerchaseDetailID", "PerchaseDetailID");
            return View();
        }

        // POST: /AssetPurchaseDetailSerialNumbe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AssetPurchaseDetailSerialNumberID,PerchaseDetailID,SerialNumber")] AssetPurchaseDetailSerialNumber assetpurchasedetailserialnumber)
        {
            if (ModelState.IsValid)
            {
                _assetPurchaseDetailSerialNumberManager.Add(assetpurchasedetailserialnumber);
                return RedirectToAction("Index");
            }
            var assetPurchaseDetailID = _assetPurchaseDetailManager.GetAll();
            ViewBag.PerchaseDetailID = new SelectList(assetPurchaseDetailID, "PerchaseDetailID", "PerchaseDetailID");
            return View(assetpurchasedetailserialnumber);
        }

        // GET: /AssetPurchaseDetailSerialNumbe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseDetailSerialNumber assetpurchasedetailserialnumber = _assetPurchaseDetailSerialNumberManager.GetById((int) id);
            if (assetpurchasedetailserialnumber == null)
            {
                return HttpNotFound();
            }
            var assetPurchaseDetailID = _assetPurchaseDetailManager.GetAll();
            ViewBag.PerchaseDetailID = new SelectList(assetPurchaseDetailID, "PerchaseDetailID", "PerchaseDetailID");
            return View(assetpurchasedetailserialnumber);
        }

        // POST: /AssetPurchaseDetailSerialNumbe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AssetPurchaseDetailSerialNumberID,PerchaseDetailID,SerialNumber")] AssetPurchaseDetailSerialNumber assetpurchasedetailserialnumber)
        {
            if (ModelState.IsValid)
            {
                _assetPurchaseDetailSerialNumberManager.Update(assetpurchasedetailserialnumber);
                return RedirectToAction("Index");
            }
            var assetPurchaseDetailID = _assetPurchaseDetailManager.GetAll();
            ViewBag.PerchaseDetailID = new SelectList(assetPurchaseDetailID, "PerchaseDetailID", "PerchaseDetailID");
            return View(assetpurchasedetailserialnumber);
        }

        // GET: /AssetPurchaseDetailSerialNumbe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetPurchaseDetailSerialNumber assetpurchasedetailserialnumber =_assetPurchaseDetailSerialNumberManager.GetById((int) id);
            if (assetpurchasedetailserialnumber == null)
            {
                return HttpNotFound();
            }
            return View(assetpurchasedetailserialnumber);
        }

        // POST: /AssetPurchaseDetailSerialNumbe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _assetPurchaseDetailSerialNumberManager.Remove(id);
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
