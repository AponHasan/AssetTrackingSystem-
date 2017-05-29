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
    public class VendorController : Controller
    {
        //private AssetTrackDbContext db = new AssetTrackDbContext();
        private VendorManager _vendorManager;

        public VendorController()
        {
            _vendorManager = new VendorManager();
        }

        
        // GET: /Vendor/
        public ActionResult Index()
        {
            var vendors = _vendorManager.GetAll();
            return View(vendors.ToList());
        }

        // GET: /Vendor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = _vendorManager.GetById((int) id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: /Vendor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Vendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="VendorID,VendorName")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {

                _vendorManager.Add(vendor);
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        // GET: /Vendor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = _vendorManager.GetById((int) id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: /Vendor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="VendorID,VendorName")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _vendorManager.Update(vendor);
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        // GET: /Vendor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = _vendorManager.GetById((int) id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: /Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _vendorManager.Remove(id);
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
