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

        [Authorize(Roles = "Administrateur")]
        [HttpGet]
        public ActionResult EditCategorie(int? id)
        {


            if (id.HasValue)
            {
                Categorie categorie = contexteEF.Categorie.Single(ca => ca.CategoryID == id);
                CategorieEditee categorieEditee = AutoMapper.Mapper.Map<CategorieEditee>(categorie);
                return View(categorieEditee);
            }
            else
            {
                // Pas d'ID : création
                return View(new CategorieEditee());
            }
        }

        [Authorize(Roles = "Administrateur")]
        [HttpPost]
        public ActionResult EditCategorie(CategorieEditee categorie)
        {
            if (!ModelState.IsValid)
            {
                return View(categorie);
            }

            if (categorie.CategoryID.HasValue)
            {
                Categorie categorieDB = contexteEF.Categorie.Single(ca => ca.CategoryID == categorie.CategoryID);
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

        [Authorize(Roles = "Administrateur")]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Categorie categorie = contexteEF.Categorie.Single(ca => ca.CategoryID == id);
            contexteEF.Categorie.Remove(categorie);
            contexteEF.SaveChanges();

            return Json(new { Suppression = "OK" });
        }
    }
}