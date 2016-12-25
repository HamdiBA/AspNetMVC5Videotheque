using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        [HttpGet]
        public ActionResult EditArticle(int? id)
        {
           
                Article article = contexteEF.Article.Single(p => p.ID == id);
                return View(article);
           
        }
    }
}