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
    public class CategoryController : Controller
    {
        private AssetTrackDbContext db = new AssetTrackDbContext();
        private CategoryManager _categoryManager;
        private GeneralCategoryManager _generalCategoryManager;


        public CategoryController()
        {
            _categoryManager=new CategoryManager();
            _generalCategoryManager = new GeneralCategoryManager();
        }
        // GET: /Category/
        public ActionResult Index()
        {
            var categories = _categoryManager.GetAll();
            return View(categories.ToList());
        }

        // GET: /Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryManager.GetById((int) id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var generalCategoryList = _generalCategoryManager.GetAll();
            ViewBag.GeneralCategoryID = new SelectList(generalCategoryList, "GeneralCategoryID", "GeneralCategoryName");
            return View(category);
        }

        // GET: /Category/Create
        public ActionResult Create()
        {
            var generalCategoryList = _generalCategoryManager.GetAll();
            ViewBag.GeneralCategoryID = new SelectList(generalCategoryList, "GeneralCategoryID", "GeneralCategoryName");
            return View();
        }

        // POST: /Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CategoryID,GeneralCategoryID,CategoryName,CategoryCode,CategoryDescription")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.Add(category);
                return RedirectToAction("Index");
            }

            var generalCategoryList = _generalCategoryManager.GetAll();
            ViewBag.GeneralCategoryID = new SelectList(generalCategoryList, "GeneralCategoryID", "GeneralCategoryName"); 
            return View(category);
        }

        // GET: /Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryManager.GetById((int) id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var generalCategoryList = _generalCategoryManager.GetAll();
            ViewBag.GeneralCategoryID = new SelectList(generalCategoryList, "GeneralCategoryID", "GeneralCategoryName");
            return View(category);
        }

        // POST: /Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CategoryID,GeneralCategoryID,CategoryName,CategoryCode,CategoryDescription")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.Update(category);
                return RedirectToAction("Index");
            }
            var generalCategoryList = _generalCategoryManager.GetAll();
            ViewBag.GeneralCategoryID = new SelectList(generalCategoryList, "GeneralCategoryID", "GeneralCategoryName");
            return View(category);
        }

        // GET: /Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryManager.GetById((int) id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: /Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _categoryManager.Remove(id);
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
