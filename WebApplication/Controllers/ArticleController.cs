using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using DAL;

namespace WebApplication.Controllers
{
    public class ArticleController : Controller
    {
        private LocatMe_BDEntities contexteEF = new LocatMe_BDEntities();

        // GET: Article
        public ActionResult ListeArticle()
        {
            
            List<Article> articles = contexteEF.Article.ToList();
            return View(articles);
        }


        [Authorize(Roles = "Administrateur")]
        [HttpGet]
        public ActionResult EditArticle(int? id)
        {

            ViewBag.Category = new SelectList(contexteEF.Categorie, "CategoryID", "CategoryName");
            ViewBag.Genre = new SelectList(contexteEF.Genre, "GenreID", "GenreName");

            if (id.HasValue)
            {
                Article article = contexteEF.Article.Single(a => a.ArticleID == id);
                ArticleEditee articleEditee = AutoMapper.Mapper.Map<ArticleEditee>(article);
                return View(articleEditee);
            }
            else
            {
                // Pas d'ID : création
                return View(new ArticleEditee());
            }
        }

        [Authorize(Roles = "Administrateur")]
        [HttpPost]
        public ActionResult EditArticle(ArticleEditee article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }

            if (article.ArticleID.HasValue)
            {
                Article articleDB = contexteEF.Article.Single(a => a.ArticleID == article.ArticleID);
                articleDB = AutoMapper.Mapper.Map<ArticleEditee, Article>(article, articleDB);
            }

            else
            {
                var nouvelleArticle = AutoMapper.Mapper.Map<Article>(article);
                //int idMax = contexteEF.Article.Max(p => p.ArticleID);
                //nouvelleArticle.ArticleID = idMax + 1;

                contexteEF.Article.Add(nouvelleArticle);
            }

            contexteEF.SaveChanges();

            return RedirectToAction("ListeArticle");
        }


        [Authorize(Roles = "Administrateur")]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Article article = contexteEF.Article.Single(a => a.ArticleID == id);
            contexteEF.Article.Remove(article);
            contexteEF.SaveChanges();

            return Json(new { Suppression = "OK" });
        }
    }
}