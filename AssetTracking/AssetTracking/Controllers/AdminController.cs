using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTracking.BLL;
using AssetTracking.Models.Interfaces.IModelManager;
using AssetTracking.Models.Models;

namespace AssetTracking.Controllers
{
    public class AdminController : Controller
    {
        private IOrganizationManager _organizationManager;

        // GET: /Organization/
        public AdminController()
        {
            _organizationManager = new OrganizationManager();
        }
        public ActionResult Index()
        {           
            return View();
        }



        //Organization Control Action
        //List of organization
        public ActionResult ListOfOrganization()
        {
            var org = _organizationManager.GetAll();
            return View(org.ToList());
        }
        //end
        //create organization
        public ActionResult CreateOrganization()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrganization([Bind(Include = "OrganizationID,OrganizationName,OrganizationShortName,OrganizationLocation")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                _organizationManager.Add(organization);
                return RedirectToAction("ListOfOrganization");
            }

            return View(organization);
        }

        //Edit Organization
	}
}