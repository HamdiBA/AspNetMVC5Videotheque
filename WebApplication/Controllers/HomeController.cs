using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using DAL;
using System.Web.Security;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utilisateur model, string returnUrl)
        {
            LocatMe_BDEntities contexteEF = new LocatMe_BDEntities();
            var dataItem = contexteEF.Utilisateur.Where(x => x.Pseudo == model.Pseudo && x.Mot_de_passe == model.Mot_de_passe).First();
            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.Pseudo, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                         && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid user/pass");
                return View();
            }
        }


        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }




    }
}