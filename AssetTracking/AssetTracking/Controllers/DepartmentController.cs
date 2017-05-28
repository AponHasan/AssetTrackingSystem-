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
    public class DepartmentController : Controller
    {
        private IDepartmentManager _departmentManager;
        private IOrganizationBranchManager _organizationBranchManager;

        public DepartmentController()
        {
            _departmentManager = new DepartmentManager();
            _organizationBranchManager = new OrganizationBranchManager();
        }
        // GET: /Department/
        public ActionResult Index()
        {
            var departments = _departmentManager.GetAll();
            return View(departments.ToList());
        }

        // GET: /Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentManager.GetById((int) id);
            if (department == null)
            {
                return HttpNotFound();
            }
            var organizationBranchList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchList, "OrganizationBranchID", "OrganizationBranchName");
            return View(department);
        }

        // GET: /Department/Create
        public ActionResult Create()
        {
            var organizationBranchList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchList, "OrganizationBranchID", "OrganizationBranchName");
            return View();
        }

        // POST: /Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DepartmentID,OrganizationBranchID,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                //db.Departments.Add(department);
                //db.SaveChanges();
                _departmentManager.Add(department);
                return RedirectToAction("Index");
            }

            var organizationBranchList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchList, "OrganizationBranchID", "OrganizationBranchName");
            return View(department);
        }

        // GET: /Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentManager.GetById((int) id);
            if (department == null)
            {
                return HttpNotFound();
            }
            var organizationBranchList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchList, "OrganizationBranchID", "OrganizationBranchName");
            return View(department);
        }

        // POST: /Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DepartmentID,OrganizationBranchID,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(department).State = EntityState.Modified;
                //db.SaveChanges();
                _departmentManager.Update(department);
                return RedirectToAction("Index");
            }
            var organizationBranchList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchList, "OrganizationBranchID", "OrganizationBranchName");
            return View(department);
        }

        // GET: /Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentManager.GetById((int) id);
            if (department == null)
            {
                return HttpNotFound();
            }
            var organizationBranchList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationBranchID = new SelectList(organizationBranchList, "OrganizationBranchID", "OrganizationBranchName");
            return View(department);
        }

        // POST: /Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = _departmentManager.GetById((int) id);
            _departmentManager.Remove(id);
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
