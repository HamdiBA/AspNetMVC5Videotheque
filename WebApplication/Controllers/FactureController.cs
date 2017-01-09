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
            return View(factures);
        }


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
        [HttpGet]
        public ActionResult EditFacture(int? id)
        {

            ViewBag.Location = new SelectList(contexteEF.Location, "LocationID", "EtatLocation");

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

        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("ViewFacture");
        }
    }
}