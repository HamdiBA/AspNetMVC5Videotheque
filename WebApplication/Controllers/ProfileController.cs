using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using DAL;

namespace WebApplication.Controllers
{
    public class ProfileController : Controller
    {
        private LocatMe_BDEntities contexteEF = new LocatMe_BDEntities();

        // GET: Article
        public ActionResult Profil()
        {
            var profile = contexteEF.Utilisateur.Where(r => r.UserName == User.Identity.Name).First();

            return View(profile);
        }

        [HttpGet]
        public ActionResult EditProfil(int? id)
        {
            if (id.HasValue)
            {
                Utilisateur user = contexteEF.Utilisateur.Single(u => u.UserID == id);
                UserEditee userEditee = AutoMapper.Mapper.Map<UserEditee>(user);
                return View(userEditee);
            }
            else
            {
                // Pas d'ID : création
                return View(new UserEditee());
            }
        }

        [HttpPost]
        public ActionResult EditProfil(UserEditee user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (user.UserID.HasValue)
            {
                Utilisateur userDB = contexteEF.Utilisateur.Single(u => u.UserID == user.UserID);
                userDB = AutoMapper.Mapper.Map<UserEditee, Utilisateur>(user, userDB);
            }


            contexteEF.SaveChanges();

            return RedirectToAction("Profil");
        }

       

    }
}