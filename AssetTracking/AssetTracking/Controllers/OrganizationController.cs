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
using AssetTracking.Models.Interfaces;
using AssetTracking.Models.Interfaces.IModelManager;

namespace AssetTracking.Controllers
{
    public class OrganizationController : Controller
    {
        //private AssetTrackDbContext db = new AssetTrackDbContext();
        private IOrganizationManager _organizationManager;

        // GET: /Organization/
        public OrganizationController()
        {
            _organizationManager = new OrganizationManager();
        }
        public ActionResult Index()
        {
            var org = _organizationManager.GetAll();
            return View(org.ToList());
        }

        // GET: /Organization/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = _organizationManager.GetById((int) id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: /Organization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Organization/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OrganizationID,OrganizationName,OrganizationShortName,OrganizationLocation")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                //db.Organizations.Add(organization);
                //db.SaveChanges();
                _organizationManager.Add(organization);
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        // GET: /Organization/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = _organizationManager.GetById((int) id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: /Organization/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OrganizationID,OrganizationName,OrganizationShortName,OrganizationLocation")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(organization).State = EntityState.Modified;
                //db.SaveChanges();
                _organizationManager.Update(organization);
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        // GET: /Organization/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = _organizationManager.GetById((int) id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: /Organization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _organizationManager.Remove(id);
            //db.Organizations.Remove(organization);
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
