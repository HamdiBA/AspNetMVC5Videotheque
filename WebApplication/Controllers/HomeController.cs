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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(Utilisateur model, string returnUrl)
        {
            LocatMe_BDEntities contexteEF = new LocatMe_BDEntities();
           
                var dataItem = contexteEF.Utilisateur.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
            
                if (dataItem != null)
                {

                    FormsAuthentication.SetAuthCookie(dataItem.UserName, false);
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
                    ModelState.AddModelError(String.Empty, "Vérifier votre login et mot de passe svp");

                }
            
            
                return View();

            
        }


        [Authorize]
        public ActionResult SignOut()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }




    }
}