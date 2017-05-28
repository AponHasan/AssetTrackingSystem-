using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using AssetTracking.BLL;
using AssetTracking.Models.Models;
using AssetTracking.Models.Database;
using AssetTracking.Models.Interfaces.IModelManager;

namespace AssetTracking.Controllers
{
    public class EmployeeController : Controller
    {
        private AssetTrackDbContext db = new AssetTrackDbContext();

        private IEmployeeManager _employeeManager;

        private IDesignationManager _designationManager;

        private IDepartmentManager _departmentManager;

        public EmployeeController()
        {
            _employeeManager = new EmployeeManager();
            _designationManager = new DesignationManager();
            _departmentManager = new DepartmentManager();
        }
        
        // GET: /Employee/
        public ActionResult Index()
        {
            //var employees = db.Employees.Include(e => e.Department).Include(e => e.Designation);
            var employees = _employeeManager.GetAll();
            return View(employees.ToList());
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            var DepartmentsList = _departmentManager.GetAll();
            var DesignationsList = _designationManager.GetAll();
            ViewBag.DepartmentID = new SelectList(DepartmentsList, "DepartmentID", "DepartmentName");
            ViewBag.DesignationID = new SelectList(DesignationsList, "DesignationID", "DesignationName");
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EmployeeID,DepartmentID,EmployeeName,DesignationID,ContactNo,Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //db.Employees.Add(employee);
                //db.SaveChanges();
                _employeeManager.Add(employee);
                return RedirectToAction("Index");
            }

            var DepartmentsList = _departmentManager.GetAll();
            var DesignationsList = _designationManager.GetAll();
            ViewBag.DepartmentID = new SelectList(DepartmentsList, "DepartmentID", "DepartmentName");
            ViewBag.DesignationID = new SelectList(DesignationsList, "DesignationID", "DesignationName");
            return View(employee);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.GetById((int) id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            var DepartmentsList = _departmentManager.GetAll();
            var DesignationsList = _designationManager.GetAll();
            ViewBag.DepartmentID = new SelectList(DepartmentsList, "DepartmentID", "DepartmentName");
            ViewBag.DesignationID = new SelectList(DesignationsList, "DesignationID", "DesignationName");
            return View(employee);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EmployeeID,DepartmentID,EmployeeName,DesignationID,ContactNo,Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(employee).State = EntityState.Modified;
                //db.SaveChanges();
                _employeeManager.Update(employee);
                return RedirectToAction("Index");
            }
            var DepartmentsList = _departmentManager.GetAll();
            var DesignationsList = _designationManager.GetAll();
            ViewBag.DepartmentID = new SelectList(DepartmentsList, "DepartmentID", "DepartmentName");
            ViewBag.DesignationID = new SelectList(DesignationsList, "DesignationID", "DesignationName");
            return View(employee);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.GetById((int) id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _employeeManager.Remove(id);
            //db.Employees.Remove(employee);
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
