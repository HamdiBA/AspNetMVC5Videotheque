using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using DAL;

namespace WebApplication.Controllers
{
    public class GenreController : Controller
    {
        private LocatMe_BDEntities contexteEF = new LocatMe_BDEntities();

        // GET: Genre
        public ActionResult ListeGenre()
        {
            List<Genre> genres = contexteEF.Genre.ToList();
            return View(genres);
        }

        [Authorize(Roles = "Administrateur")]
        [HttpGet]
        public ActionResult EditGenre(int? id)
        {


            if (id.HasValue)
            {
                Genre genre = contexteEF.Genre.Single(g => g.GenreID == id);
                GenreEditee genreEditee = AutoMapper.Mapper.Map<GenreEditee>(genre);
                return View(genreEditee);
            }
            else
            {
                // Pas d'ID : création
                return View(new GenreEditee());
            }
        }

        [Authorize(Roles = "Administrateur")]
        [HttpPost]
        public ActionResult EditGenre(GenreEditee genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre);
            }

            if (genre.GenreID.HasValue)
            {
                Genre genreDB = contexteEF.Genre.Single(g => g.GenreID == genre.GenreID);
                genreDB = AutoMapper.Mapper.Map<GenreEditee, Genre>(genre, genreDB);
            }

            else
            {
                var nouvelleGenre = AutoMapper.Mapper.Map<Genre>(genre);
                //int idMax = contexteEF.Genre.Max(p => g.ID);
                //nouvelleGenre.ID = idMax + 1;

                contexteEF.Genre.Add(nouvelleGenre);
            }

            contexteEF.SaveChanges();

            return RedirectToAction("ListeGenre");
        }

        [Authorize(Roles = "Administrateur")]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Genre genre = contexteEF.Genre.Single(g => g.GenreID == id);
            contexteEF.Genre.Remove(genre);
            contexteEF.SaveChanges();

            return Json(new { Suppression = "OK" });
        }
    }
}