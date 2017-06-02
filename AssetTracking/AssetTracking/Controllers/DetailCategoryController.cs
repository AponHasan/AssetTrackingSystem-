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
    public class DetailCategoryController : Controller
    {
        private AssetTrackDbContext db = new AssetTrackDbContext();
        private DetailCategoryManager _detailCategoryManager;
        private SubCategoryManager _subCategoryManager;

        public DetailCategoryController()
        {
            _subCategoryManager = new SubCategoryManager();
            _detailCategoryManager = new DetailCategoryManager();
        }

        // GET: /DetailCategory/
        public ActionResult Index()
        {
            //var detailcategories = db.DetailCategories.Include(d => d.SubCategory);

            
            var detailcategories = _detailCategoryManager.GetAll();
            return View(detailcategories.ToList());
        }

        // GET: /DetailCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailCategory detailcategory = _detailCategoryManager.GetById((int) id);
            if (detailcategory == null)
            {
                return HttpNotFound();
            }
            return View(detailcategory);
        }

        // GET: /DetailCategory/Create
        public ActionResult Create()
        {
            var subCategories = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategories, "SubCategoryID", "SubCategoryName");
            return View();
        }

        // POST: /DetailCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DetailCategoryID,SubCategoryID,DetailCategoryName,DetailCategoryCode,DetailCategoryDescription")] DetailCategory detailcategory)
        {
            if (ModelState.IsValid)
            {
                _detailCategoryManager.Add(detailcategory);
                return RedirectToAction("Index");
            }

            var subCategories = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategories, "SubCategoryID", "SubCategoryName");
            return View(detailcategory);
        }

        // GET: /DetailCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailCategory detailcategory = _detailCategoryManager.GetById((int)id);
            if (detailcategory == null)
            {
                return HttpNotFound();
            }
            var subCategories = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategories, "SubCategoryID", "SubCategoryName");
            return View(detailcategory);
        }

        // POST: /DetailCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DetailCategoryID,SubCategoryID,DetailCategoryName,DetailCategoryCode,DetailCategoryDescription")] DetailCategory detailcategory)
        {
            if (ModelState.IsValid)
            {
                _detailCategoryManager.Update(detailcategory);
                return RedirectToAction("Index");
            }
            var subCategories = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategories, "SubCategoryID", "SubCategoryName");
            return View(detailcategory);
        }

        // GET: /DetailCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailCategory detailcategory = _detailCategoryManager.GetById((int)id);
            if (detailcategory == null)
            {
                return HttpNotFound();
            }
            return View(detailcategory);
        }

        // POST: /DetailCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _detailCategoryManager.Remove(id);
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
