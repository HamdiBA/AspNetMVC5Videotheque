using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using DAL;

namespace WebApplication.Controllers
{
    public class CategorieController : Controller
    {
        private LocatMe_BDEntities contexteEF = new LocatMe_BDEntities();

        // GET: Categorie
        public ActionResult ListeCategorie()
        {
            List<Categorie> categories = contexteEF.Categorie.ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult EditCategorie(int? id)
        {


            if (id.HasValue)
            {
                Categorie categorie = contexteEF.Categorie.Single(ca => ca.ID == id);
                CategorieEditee categorieEditee = AutoMapper.Mapper.Map<CategorieEditee>(categorie);
                return View(categorieEditee);
            }
            else
            {
                // Pas d'ID : création
                return View(new CategorieEditee());
            }
        }

        [HttpPost]
        public ActionResult EditCategorie(CategorieEditee categorie)
        {
            if (!ModelState.IsValid)
            {
                return View(categorie);
            }

            if (categorie.ID.HasValue)
            {
                Categorie categorieDB = contexteEF.Categorie.Single(ca => ca.ID == categorie.ID);
                categorieDB = AutoMapper.Mapper.Map<CategorieEditee, Categorie>(categorie, categorieDB);
            }

            else
            {
                var nouvelleCategorie = AutoMapper.Mapper.Map<Categorie>(categorie);
                //int idMax = contexteEF.Categorie.Max(p => ca.ID);
                //nouvelleCategorie.ID = idMax + 1;

                contexteEF.Categorie.Add(nouvelleCategorie);
            }

            contexteEF.SaveChanges();

            return RedirectToAction("ListeCategorie");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            Categorie categorie = contexteEF.Categorie.Single(ca => ca.ID == id);
            contexteEF.Categorie.Remove(categorie);
            contexteEF.SaveChanges();

            return Json(new { Suppression = "OK" });
        }
    }
}