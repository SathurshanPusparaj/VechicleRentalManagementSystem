using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using vehiclerent.Models;

namespace vehiclerent.Controllers
{
    public class RenterController : Controller
    {
        private ContextClass context = new ContextClass();
        // GET: Renter
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Renter renter)
        {
            if (RenterVaild(renter.RenterEMail, renter.RenterPassword))
            {
                FormsAuthentication.SetAuthCookie(renter.RenterEMail, renter.RenterRememberMe ? true : false);
                var uname = context.renterC.Where(x => x.RenterEMail == renter.RenterEMail).Select(y => y.RenterName).SingleOrDefault();
                Session["rname"] = uname;
                return RedirectToAction("Index", "Vehicle");
            }
            else
            {
                ModelState.AddModelError("", "Please check your user name and password");
            }
            return View(renter);
        }

        private bool RenterVaild(String renterEmail, String password)
        {
            bool valid = false;
            int usercount = context.renterC.Count(x => x.RenterEMail == renterEmail && x.RenterPassword == password);
            if (usercount == 1)
            {
                valid = true;
            }

            return valid;
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Renter newrenter)
        {
            if (ModelState.IsValid)
            {
                context.renterC.Add(newrenter);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newrenter);
        }

    }
}