using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using DAL;

namespace WebApplication.Controllers
{
    public class LocationController : Controller
    {
        private LocatMe_BDEntities contexteEF = new LocatMe_BDEntities();

        // GET: Location
        public ActionResult ListeLocation()
        {
            List<Location> locations = contexteEF.Location.ToList();
            return View(locations);
        }

        [HttpGet]
        public ActionResult EditLocation(int? id)
        {
            if (id.HasValue)
            {
                Location location = contexteEF.Location.Single(p => p.ID == id);
                LocationEditee locationEditee = AutoMapper.Mapper.Map<LocationEditee>(location);
                return View(locationEditee);
            }
            else
            {
                // Pas d'ID : création
                return View(new LocationEditee());
            }
        }

        [HttpPost]
        public ActionResult EditLocation(LocationEditee location)
        {
            if (!ModelState.IsValid)
            {
                return View(location);
            }

            if (location.ID.HasValue)
            {
                Location locationDB = contexteEF.Location.Single(p => p.ID == location.ID);
                locationDB = AutoMapper.Mapper.Map<LocationEditee, Location>(location, locationDB);
            }

            else
            {
                var nouvelleLocation = AutoMapper.Mapper.Map<Location>(location);
                int idMax = contexteEF.Location.Max(p => p.ID);
                nouvelleLocation.ID = idMax + 1;

                contexteEF.Location.Add(nouvelleLocation);
            }

            contexteEF.SaveChanges();

            return RedirectToAction("ListeLocation");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            Location location = contexteEF.Location.Single(p => p.ID == id);
            contexteEF.Location.Remove(location);
            contexteEF.SaveChanges();

            return Json(new { Suppression = "OK" });
        }
    }
}