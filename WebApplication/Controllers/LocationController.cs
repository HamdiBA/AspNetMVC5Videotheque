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
            //List<Location> locations = contexteEF.Location.GroupBy(a => a.LocationID).Select(b => b.FirstOrDefault()).ToList();

            var factures = (from f in contexteEF.Facture
                            group f by new { f.LocationID, f.FactureID } into locationGroup
                            select new
                            {
                                locationGroup.Key.LocationID,
                                locationGroup.Key.FactureID,
                                NumberInGroup = locationGroup.Count()
                            }).ToList();

            return View(factures);
        }

        [HttpGet]
        public ActionResult EditLocation(int? id)
        {

            ViewBag.Article = new SelectList(contexteEF.Article, "ArticleID", "ArticleName");
            ViewBag.Customer = new SelectList(contexteEF.Client, "CustomerID", "Name");
            ViewBag.User = new SelectList(contexteEF.Utilisateur, "UserID", "Name");


            if (id.HasValue)
            {
                Location location = contexteEF.Location.Single(l => l.LocationID == id);
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

            if (location.LocationID.HasValue)
            {
                Location locationDB = contexteEF.Location.Single(l => l.LocationID == location.LocationID);
                locationDB = AutoMapper.Mapper.Map<LocationEditee, Location>(location, locationDB);
            }

            else
            {
                var nouvelleLocation = AutoMapper.Mapper.Map<Location>(location);
                //int idMax = contexteEF.Location.Max(l => l.LocationID);
                //nouvelleLocation.LocationID = idMax + 1;

                contexteEF.Location.Add(nouvelleLocation);
            }

            contexteEF.SaveChanges();

            return RedirectToAction("ListeLocation");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            Location location = contexteEF.Location.Single(l => l.LocationID == id);
            contexteEF.Location.Remove(location);
            contexteEF.SaveChanges();

            return Json(new { Suppression = "OK" });
        }
    }
}