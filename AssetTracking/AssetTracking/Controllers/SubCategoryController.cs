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
    public class SubCategoryController : Controller
    {
        private AssetTrackDbContext db = new AssetTrackDbContext();
        private SubCategoryManager _subCategoryManager;
        private CategoryManager _categoryManager;


        public SubCategoryController()
        {
            _subCategoryManager = new SubCategoryManager();
            _categoryManager = new CategoryManager();
        }
        // GET: /SubCategory/
        public ActionResult Index()
        {
            var subcategories = _subCategoryManager.GetAll();
            return View(subcategories.ToList());
        }

        // GET: /SubCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subcategory = _subCategoryManager.GetById((int) id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            var categoryList = _categoryManager.GetAll();
            ViewBag.CategoryID = new SelectList(categoryList, "CategoryID", "CategoryName");            
            return View(subcategory);
        }

        // GET: /SubCategory/Create
        public ActionResult Create()
        {
            var categoryList = _categoryManager.GetAll();
            ViewBag.CategoryID = new SelectList(categoryList, "CategoryID", "CategoryName");
            return View();
        }

        // POST: /SubCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SubCategoryID,CategoryID,SubCategoryName,SubCategoryCode,SubCategoryDescription")] SubCategory subcategory)
        {
            if (ModelState.IsValid)
            {
                //db.SubCategories.Add(subcategory);
                //db.SaveChanges();
                _subCategoryManager.Add(subcategory);
                return RedirectToAction("Index");
            }

            var categoryList = _categoryManager.GetAll();
            ViewBag.CategoryID = new SelectList(categoryList, "CategoryID", "CategoryName");
            return View(subcategory);
        }

        // GET: /SubCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subcategory = _subCategoryManager.GetById((int) id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            var categoryList = _categoryManager.GetAll();
            ViewBag.CategoryID = new SelectList(categoryList, "CategoryID", "CategoryName");
            return View(subcategory);
        }

        // POST: /SubCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SubCategoryID,CategoryID,SubCategoryName,SubCategoryCode,SubCategoryDescription")] SubCategory subcategory)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(subcategory).State = EntityState.Modified;
                //db.SaveChanges();
                _subCategoryManager.Update(subcategory);
                return RedirectToAction("Index");
            }
            var categoryList = _categoryManager.GetAll();
            ViewBag.CategoryID = new SelectList(categoryList, "CategoryID", "CategoryName");
            return View(subcategory);
        }

        // GET: /SubCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subcategory = _subCategoryManager.GetById((int) id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }

        // POST: /SubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _subCategoryManager.Remove(id);
            //db.SubCategories.Remove(subcategory);
            //db.SaveChanges();
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
