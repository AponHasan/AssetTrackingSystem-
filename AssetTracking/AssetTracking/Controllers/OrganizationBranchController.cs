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
    public class OrganizationBranchController : Controller
    {
        //private AssetTrackDbContext db = new AssetTrackDbContext();
        private IOrganizationBranchManager _organizationBranchManager;

        // GET: /Organization/
        public OrganizationBranchController()
        {
            _organizationBranchManager = new OrganizationBranchManager();
        }

        // GET: /OrganizationBranch/
        public ActionResult Index()
        {
            var organizationbranches = _organizationBranchManager.GetAll();
            return View(organizationbranches.ToList());
        }

        // GET: /OrganizationBranch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationBranch organizationbranch = _organizationBranchManager.GetById((int)id);
            if (organizationbranch == null)
            {
                return HttpNotFound();
            }
            return View(organizationbranch);
        }

        // GET: /OrganizationBranch/Create
        public ActionResult Create()
        {
            var organizationList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationID = new SelectList(organizationList, "OrganizationID", "OrganizationName");
            return View();
        }

        // POST: /OrganizationBranch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OrganizationBranchID,OrganizationID,OrganizationBranchName,OrganizatioBranchShortName")] OrganizationBranch organizationbranch)
        {
            if (ModelState.IsValid)
            {
                //db.OrganizationBranches.Add(organizationbranch);
                //db.SaveChanges();
                _organizationBranchManager.Add(organizationbranch);
                return RedirectToAction("Index");
            }

            var organizationList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationID = new SelectList(organizationList, "OrganizationID", "OrganizationName",organizationbranch.OrganizationID);
            return View(organizationbranch);
        }

        // GET: /OrganizationBranch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationBranch organizationbranch = _organizationBranchManager.GetById((int)id);
            if (organizationbranch == null)
            {
                return HttpNotFound();
            }
            var organizationList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationID = new SelectList(organizationList, "OrganizationID", "OrganizationName");
            return View(organizationbranch);
        }

        // POST: /OrganizationBranch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OrganizationBranchID,OrganizationID,OrganizationBranchName,OrganizatioBranchShortName")] OrganizationBranch organizationbranch)
        {
            if (ModelState.IsValid)
            {
                _organizationBranchManager.Update(organizationbranch);
                return RedirectToAction("Index");
            } 
            var organizationList = _organizationBranchManager.GetAll();
            ViewBag.OrganizationID = new SelectList(organizationList, "OrganizationID", "OrganizationName");
            return View(organizationbranch);
        }

        // GET: /OrganizationBranch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationBranch organizationbranch = _organizationBranchManager.GetById((int)id);
            if (organizationbranch == null)
            {
                return HttpNotFound();
            }
            return View(organizationbranch);
        }

        // POST: /OrganizationBranch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _organizationBranchManager.Remove(id);
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
