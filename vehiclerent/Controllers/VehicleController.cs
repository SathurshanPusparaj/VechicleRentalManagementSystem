using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using vehiclerent.Models;

namespace vehiclerent.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        private ContextClass context = new ContextClass();

        public ActionResult Index()
        {
            List<Vehicle> vehicleList = context.vehicleC.Where(x=>x.RenterEMail==User.Identity.Name).ToList();
            return View(vehicleList);
        }

        public ActionResult Details(String id)
        {
            Vehicle vehicle = context.vehicleC.SingleOrDefault(x => x.VehicleId == id);
            return View(vehicle);
        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                context.vehicleC.Add(vehicle);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        public ActionResult Delete(String id)
        {
            Vehicle vehicle = context.vehicleC.SingleOrDefault(x => x.VehicleId == id);
            return View(vehicle);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(String id)
        {
            Vehicle vehicle = context.vehicleC.SingleOrDefault(x => x.VehicleId == id);
            context.vehicleC.Remove(vehicle);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(String id)
        {
            Vehicle vehicle = context.vehicleC.SingleOrDefault(x => x.VehicleId == id);
            return View(vehicle);
        }
        [HttpPost]
        public ActionResult Edit(String id, Vehicle evehicle)
        {
            Vehicle vehicle = context.vehicleC.SingleOrDefault(x => x.VehicleId == id);

            if (ModelState.IsValid)
            {
                vehicle.air = evehicle.air;
                vehicle.Description = evehicle.Description;
                vehicle.price = evehicle.price;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evehicle);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "HomeX");
        }

    }
}