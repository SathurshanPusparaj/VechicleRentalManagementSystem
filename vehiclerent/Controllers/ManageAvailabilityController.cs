using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vehiclerent.Models;

namespace vehiclerent.Controllers
{
    public class ManageAvailabilityController : Controller
    {
        // GET: ManageAvailability
        private ContextClass context = new ContextClass();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1(String id)
        {
            Session["vid"]=id;
            List<VehicleAvailability> vehicleavailability = context.vehicleAvailabilityC.Where(x => x.VehicleId == id).ToList();
            return View(vehicleavailability);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(VehicleAvailability vehicleavailability)
        {
            if (ModelState.IsValid)
            {
                vehicleavailability.VehicleId = Session["vid"].ToString();
                context.vehicleAvailabilityC.Add(vehicleavailability);
                context.SaveChanges();
                return RedirectToAction("Index1", "ManageAvailability", new { id = Session["vid"].ToString() });
            }
            return View(vehicleavailability);
        }

        public ActionResult Delete(int id)
        {
            VehicleAvailability vehicleavailability = context.vehicleAvailabilityC.SingleOrDefault(x => x.AvailabilityId == id);
            return View(vehicleavailability);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            VehicleAvailability vehicleavailability = context.vehicleAvailabilityC.SingleOrDefault(x => x.AvailabilityId == id);
            context.vehicleAvailabilityC.Remove(vehicleavailability);
            context.SaveChanges();
            return RedirectToAction("Index1", "ManageAvailability", new { id = Session["vid"].ToString() });
        }

        /*
        public ActionResult Edit(int id)
        {
            VehicleAvailability va = context.vehicleAvailabilityC.SingleOrDefault(x => x.AvailabilityId == id);
            return View(va);
        }
        [HttpPost]
        public ActionResult Edit(int id, VehicleAvailability newva)
        {
            VehicleAvailability va = context.vehicleAvailabilityC.SingleOrDefault(x => x.AvailabilityId == id);

            if (ModelState.IsValid)
            {
                //update
                va.VehicleAvailableFrom = newva.VehicleAvailableFrom;
                va.VehicleAvailableTo = newva.VehicleAvailableTo;
                va.VehicleLocation = newva.VehicleLocation;
                context.SaveChanges();
                return RedirectToAction("Index1",id);
            }
            return View(newva);
        }*/


    }
}