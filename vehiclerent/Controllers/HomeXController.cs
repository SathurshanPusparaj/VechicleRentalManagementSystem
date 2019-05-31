using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vehiclerent.Controllers
{
    public class HomeXController : Controller
    {
        // GET: HomeX
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult goToRenterLogin()
        {
            return RedirectToAction("Index", "Renter");
        }

        public ActionResult goToTenantLogin()
        {
            return RedirectToAction("Index", "Tenant");
        }
    }
}