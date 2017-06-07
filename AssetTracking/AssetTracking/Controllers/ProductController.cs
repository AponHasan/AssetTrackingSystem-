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
    public class ProductController : Controller
    {
        private AssetTrackDbContext db = new AssetTrackDbContext();
        private SubCategoryManager _subCategoryManager;
        private CategoryManager _categoryManager;
        private GeneralCategoryManager _generalCategoryManager;
        private ProductManager _productManager;


        public ProductController()
        {
            _productManager = new ProductManager();
            _subCategoryManager = new SubCategoryManager();
            _categoryManager = new CategoryManager();
            _generalCategoryManager = new GeneralCategoryManager();
        }
        // GET: /Product/
        public ActionResult Index()
        {
            var products = _productManager.GetAll();
            return View(products.ToList());
        }

        // GET: /Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productManager.GetById((int) id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            var generalCategoryList = _generalCategoryManager.GetAll();
            ViewBag.generalCategoryID = new SelectList(generalCategoryList, "GeneralCategoryID", "GeneralCategoryName");

            var categoryList = _categoryManager.GetAll();
            ViewBag.CategoryID = new SelectList(categoryList, "CategoryID", "CategoryName");

            var subCategoryList = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategoryList, "SubCategoryID", "SubCategoryName");
            return View();
        }

        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProductID,ProductCode,ProductName,SubCategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productManager.Add(product);
                return RedirectToAction("Index");
            }

            var generalCategoryList = _generalCategoryManager.GetAll();
            ViewBag.generalCategoryID = new SelectList(generalCategoryList, "GeneralCategoryID", "GeneralCategoryName");

            var categoryList = _categoryManager.GetAll();
            ViewBag.CategoryID = new SelectList(categoryList, "CategoryID", "CategoryName");

            var subCategoryList = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategoryList, "SubCategoryID", "SubCategoryName");
            return View(product);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productManager.GetById((int) id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var generalCategoryList = _generalCategoryManager.GetAll();
            ViewBag.generalCategoryID = new SelectList(generalCategoryList, "GeneralCategoryID", "GeneralCategoryName");

            var categoryList = _categoryManager.GetAll();
            ViewBag.CategoryID = new SelectList(categoryList, "CategoryID", "CategoryName");

            var subCategoryList = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategoryList, "SubCategoryID", "SubCategoryName");
            return View(product);
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProductID,ProductCode,ProductName,SubCategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productManager.Update(product);
                return RedirectToAction("Index");
            }
            var generalCategoryList = _generalCategoryManager.GetAll();
            ViewBag.generalCategoryID = new SelectList(generalCategoryList, "GeneralCategoryID", "GeneralCategoryName");

            var categoryList = _categoryManager.GetAll();
            ViewBag.CategoryID = new SelectList(categoryList, "CategoryID", "CategoryName");

            var subCategoryList = _subCategoryManager.GetAll();
            ViewBag.SubCategoryID = new SelectList(subCategoryList, "SubCategoryID", "SubCategoryName");
            return View(product);
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productManager.GetById((int) id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _productManager.Remove(id);
            return RedirectToAction("Index");
        }

        public JsonResult GetProductBySubCategory(long subcategoryId)
        {
            var subcategory = _productManager.GetProductBySubCategory(subcategoryId);
            var categoryJsonData = subcategory.Select(
                c => new
                {
                    c.ProductID,
                    c.ProductCode,
                    c.ProductName,
                    c.SubCategoryID

                });
            return Json(categoryJsonData, JsonRequestBehavior.AllowGet);
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
