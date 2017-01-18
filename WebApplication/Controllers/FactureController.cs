using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using DAL;

namespace WebApplication.Controllers
{
    public class FactureController : Controller
    {
        private LocatMe_BDEntities contexteEF = new LocatMe_BDEntities();

        // GET: Facture
        public ActionResult ListeFacture()
        {
            List<Facture> factures = contexteEF.Facture.ToList();
            //List<Facture> factures = contexteEF.Facture.ToList();
            //var factures = (from c in contexteEF.Facture
            //                group c by new { c.CustomerID, c.DateFacture } into result
            //                select new FactureEditee
            //                {

            //                    CustomerID = result.Key.CustomerID,
            //                    DateFacture = result.Key.DateFacture,
            //                    Quantity = result.Sum(b => b.Quantity),
            //                    Price = result.Sum(b => b.Price),
            //                    FactureID = result.Sum(b => b.FactureID)
            //                }).OrderByDescending(a => a.FactureID).Take(10).ToList();
            return View(factures);
        }


        //public JsonResult GetCustomerByID(int? locId)
        //{
        //    contexteEF.Configuration.ProxyCreationEnabled = false;
        //    return Json(contexteEF.Location.Where(f => f.LocationID == locId), JsonRequestBehavior.AllowGet);
        //}

        [Authorize(Roles = "Administrateur")]
        [HttpGet]
        public ActionResult EditFacture(int? id)
        {

            ViewBag.Customer = new SelectList(contexteEF.Client, "Nom_complet", "Nom_complet");
            ViewBag.ArticleID = new SelectList(contexteEF.Article, "ArticleID", "ArticleID");
            ViewBag.Article = new SelectList(contexteEF.Article, "ArticleName", "ArticleName");
            ViewBag.Categorie = new SelectList(contexteEF.Categorie, "CategoryName", "CategoryName");
            ViewBag.Quantite = new SelectList(contexteEF.Location, "Quantity", "Quantity");
            ViewBag.Price = new SelectList(contexteEF.Article, "Price", "Price");

            //List<Client> allCustomer = new List<Client>();
            //List<Location> allLocation = new List<Location>();
            ////ViewBag.Location = new SelectList(contexteEF.Location, "LocationID", "EtatLocation");

            //using (LocatMe_BDEntities dc = new LocatMe_BDEntities())
            //{
            //    allCustomer = dc.Client.OrderBy(a => a.Name).ToList();
            //    if (fb != null && fb.CustomerID > 0)
            //    {
            //        allLocation = dc.Location.Where(a => a.CustomerID.Equals(fb.CustomerID)).ToList();
            //    }
            //}



            //ViewBag.CustomerID = new SelectList(allCustomer, "CustomerID", "Name");
            //ViewBag.LocationID = new SelectList(allLocation, "LocationID", "EtatLocation");

            if (id.HasValue)
            {
                Facture facture = contexteEF.Facture.Single(f => f.FactureID == id);
                FactureEditee factureEditee = AutoMapper.Mapper.Map<FactureEditee>(facture);
                return View(factureEditee);
            }
            else
            {
                // Pas d'ID : création
                return View(new FactureEditee());
            }
        }

        //[HttpGet]
        //public JsonResult GetLocations(string customerID = "")
        //{
        //    List<Location> allLocation = new List<Location>();
        //    int ID = 0;
        //    if (int.TryParse(customerID, out ID))
        //    {
        //        using (LocatMe_BDEntities dc = new LocatMe_BDEntities())
        //        {
        //            allLocation = dc.Location.Where(a => a.CustomerID.Equals(ID)).OrderBy(a => a.EtatLocation).ToList();
        //        }
        //    }
        //    if (Request.IsAjaxRequest())
        //    {
        //        return new JsonResult
        //        {
        //            Data = allLocation,
        //            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //        };
        //    }
        //    else
        //    {
        //        return new JsonResult
        //        {
        //            Data = "Not valid request",
        //            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //        };
        //    }
        //}

        [HttpGet]
        public ActionResult ViewFacture(int? id)
        {



            if (id.HasValue)
            {

                Facture facture = contexteEF.Facture.Single(f => f.FactureID == id);
                FactureEditee factureEditee = AutoMapper.Mapper.Map<FactureEditee>(facture);
                return View(factureEditee);
            }
            else
            {
                // Pas d'ID : création
                return View(new FactureEditee());
            }
        }

        [Authorize(Roles = "Administrateur")]
        [HttpPost]
        public ActionResult EditFacture(FactureEditee facture)
        {
            if (!ModelState.IsValid)
            {
                return View(facture);
            }

            if (facture.FactureID.HasValue)
            {
                Facture factureDB = contexteEF.Facture.Single(f => f.FactureID == facture.FactureID);
                factureDB = AutoMapper.Mapper.Map<FactureEditee, Facture>(facture, factureDB);
            }

            else
            {
                var nouvelleFacture = AutoMapper.Mapper.Map<Facture>(facture);
                //int idMax = contexteEF.Facture.Max(f => f.ArticleID);
                //nouvelleFacture.FactureID = idMax + 1;

                contexteEF.Facture.Add(nouvelleFacture);
            }

            contexteEF.SaveChanges();

            return RedirectToAction("ListeFacture");
        }


        [Authorize(Roles = "Administrateur")]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Facture facture = contexteEF.Facture.Single(f => f.FactureID == id);
            contexteEF.Facture.Remove(facture);
            contexteEF.SaveChanges();

            return Json(new { Suppression = "OK" });
        }

        
    }
}