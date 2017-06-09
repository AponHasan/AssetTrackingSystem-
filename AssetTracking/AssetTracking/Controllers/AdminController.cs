using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTracking.Models.Database;
using AssetTracking.Models.Models;

namespace AssetTracking.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            if (ModelState.IsValid) // this is check validity
            {
                using (AssetTrackDbContext dc = new AssetTrackDbContext())
                {
                    var v = dc.Users.Where(a => a.UserName.Equals(u.UserName) && a.Password.Equals(u.Password)).FirstOrDefault();


                    if (v != null)
                    {
                        Session["LogedUserID"] = v.UserID.ToString();
                        Session["LogedUserFullname"] = v.UserName.ToString();
                        return RedirectToAction("Index","Organization");
                    }

                }
            }
            return View(u);
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login", "Admin");
        }

	}
}