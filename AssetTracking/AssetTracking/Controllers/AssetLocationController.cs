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

namespace AssetTracking.Areas.Admin.Controllers
{
    public class AssetLocationController : Controller
    {
        //private AssetTrackDbContext db = new AssetTrackDbContext();

        private IAssetLocationManager _assetLocationManager;
        private IOrganizationBranchManager _organizationBranchManager;

        public AssetLocationController()
        {
            _assetLocationManager = new AssetLocationManager();
            _organizationBranchManager = new OrganizationBranchManager();
        }
        // GET: /AssetLocation/
        public ActionResult Index()
        {
            var assetlocations = _assetLocationManager.GetAll();
            return View(assetlocations.ToList());
        }

        // GET: /AssetLocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetlocation = _assetLocationManager.GetById((int) id);
            if (assetlocation == null)
            {
                return HttpNotFound();
            }
            var organizationBranchList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchList, "OrganizationBranchID", "OrganizationBranchName");
            return View(assetlocation);
        }

        // GET: /AssetLocation/Create
        public ActionResult Create()
        {
            var organizationBranchList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchList, "OrganizationBranchID", "OrganizationBranchName");
            return View();
        }

        // POST: /AssetLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AssetLocationID,OrganizationBranchID,AssetLocationName,ShortName")] AssetLocation assetlocation)
        {
            if (ModelState.IsValid)
            {
                //db.AssetLocations.Add(assetlocation);
                //db.SaveChanges();
                _assetLocationManager.Add(assetlocation);
                return RedirectToAction("Index");
            }

            var organizationBranchList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchList, "OrganizationBranchID", "OrganizationBranchName");
            return View(assetlocation);
        }

        // GET: /AssetLocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetlocation = _assetLocationManager.GetById((int) id);
            if (assetlocation == null)
            {
                return HttpNotFound();
            }
            var organizationBranchList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchList, "OrganizationBranchID", "OrganizationBranchName");
            return View(assetlocation);
        }

        // POST: /AssetLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AssetLocationID,OrganizationBranchID,AssetLocationName,ShortName")] AssetLocation assetlocation)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(assetlocation).State = EntityState.Modified;
                //db.SaveChanges();
                _assetLocationManager.Update(assetlocation);
                return RedirectToAction("Index");
            }
            var organizationBranchList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchList, "OrganizationBranchID", "OrganizationBranchName");
            return View(assetlocation);
        }

        // GET: /AssetLocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetlocation = _assetLocationManager.GetById((int) id);
            if (assetlocation == null)
            {
                return HttpNotFound();
            }
            return View(assetlocation);
        }

        // POST: /AssetLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //AssetLocation assetlocation = db.AssetLocations.Find(id);
            //db.AssetLocations.Remove(assetlocation);
            //db.SaveChanges();
            _assetLocationManager.Remove(id);
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
