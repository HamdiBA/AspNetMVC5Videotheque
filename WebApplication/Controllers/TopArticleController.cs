using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class TopArticleController : Controller
    {
        private LocatMe_BDEntities contexteEF = new LocatMe_BDEntities();
        // GET: TopArticle
        public ActionResult ListeTopArticle()
        {

            //List <Article> articles = contexteEF.Article.ToList();
            var articles = (from c in contexteEF.Location
                            group c by c.ArticleID into result
                            select new LocationEditee
                            {
                                ArticleID = result.Key,
                                Quantity = result.Sum(b => b.Quantity),
                            }).OrderByDescending(a => a.Quantity).Take(10).ToList();
            //var articles = contexteEF.Location.GroupBy(l => l.ArticleID).Select(a => new  { qt = a.Sum(b => b.Quantity), ArticleID = a.Key }).OrderByDescending(a => a.qt).ToList();
            return View(articles);
        }
    }
}