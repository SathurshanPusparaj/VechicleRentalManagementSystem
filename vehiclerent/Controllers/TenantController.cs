using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using vehiclerent.Models;

namespace vehiclerent.Controllers
{
    public class TenantController : Controller
    {
        ContextClass db = new ContextClass();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tenant tenant)
        {
            if (checking_valid(tenant.TenantEMail, tenant.TenantPassword))
            {
                FormsAuthentication.SetAuthCookie(tenant.TenantEMail, tenant.TenantRememberMe ? true : false);
                var uname = db.tenantC.Where(x => x.TenantEMail == tenant.TenantEMail).Select(y => y.TenantName).SingleOrDefault();
                Session["tname"] = uname;
                return RedirectToAction("viewpage", tenant);
            }
            ModelState.AddModelError("", "Please check your username or password");
            return View();
        }
        public bool checking_valid(string email, string password)
        {
            bool valid = false;

            int count = db.tenantC.Count(x => x.TenantEMail == email && x.TenantPassword == password);

            if (count == 1)
            {
                valid = true;
            }
            return valid;
        }

        [Authorize]
        public ActionResult viewpage(Tenant tenant)
        {
            if (Request.IsAuthenticated)
            {
                List<Vehicle> vh = db.vehicleC.ToList();
                return View(vh);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult viewpagelast(FormCollection form)
        {
            var val1 = form["Search"];
            var val2 = form["txtbx"];
            List<Vehicle> vh = db.vehicleC.ToList();

            if (val1 == "capacity")
            {
                int a = int.Parse(val2);
                Debug.WriteLine(a.ToString());
                vh = db.vehicleC.Where(x => x.capacity <= a).ToList();
            }

            if (val1 == "price")
            {
                float a = float.Parse(val2);
                vh = db.vehicleC.Where(x => x.price <= a).ToList();
            }

            return View(vh);
        }
        [Authorize]
        public ActionResult signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "HomeX");
        }
        [Authorize]
        public ActionResult details(string id)
        {
            Vehicle vh = db.vehicleC.Where(x => x.VehicleId == id).SingleOrDefault();
            Renter ren = db.renterC.Where(x => x.RenterEMail == vh.RenterEMail).SingleOrDefault();
            List<Vehicle> othervh = db.vehicleC.Where(x => x.price <= vh.price).ToList();


            ViewBag.othervh = othervh;


            ViewBag.Renter = "";
            ViewBag.Renter = ren;

            return View(vh);
        }
        public ActionResult maping()
        {
            return View();
        }
        [HttpPost]
        public ActionResult maping(VehicleAvailability available)
        {
            Debug.WriteLine(available.latitude);
            var find = db.vehicleAvailabilityC.Where(x => x.latitude <= available.latitude + 0.3 && x.longitude <= available.longitude || x.latitude >= available.latitude - 0.3 && x.latitude <= available.latitude).ToList();

            if (find != null)
            {
                string marker = "[";

                foreach (var item in find)
                {
                    marker += "{";
                    marker += "title:'" + item.VehicleId.ToString() + "',";
                    marker += "lat:" + item.latitude + ",";
                    marker += "lng:" + item.longitude + ",";

                    marker += "},";
                }
                marker += "]";
                Debug.WriteLine(marker);
                return RedirectToAction("findresult", new { mark = marker.ToString() });
            }
            return View();

        }
        public ActionResult findresult(string mark)
        {
            if (mark == null)
            {
                return RedirectToAction("maping");
            }
            ViewBag.Markers = mark;
            return View();
        }
        public ActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signup(Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                db.tenantC.Add(tenant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenant);
        }
    }
}