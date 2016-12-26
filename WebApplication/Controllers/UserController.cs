using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        private LocatMe_BDEntities contexteEF = new LocatMe_BDEntities();

        // GET: Cleint
        public ActionResult ListeUser()
        {
            List<User> users = contexteEF.User.ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            if (id.HasValue)
            {
                User user = contexteEF.User.Single(p => p.ID == id);
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
        public ActionResult EditUser(UserEditee user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (user.ID.HasValue)
            {
                User userDB = contexteEF.User.Single(p => p.ID == user.ID);
                userDB = AutoMapper.Mapper.Map<UserEditee, User>(user, userDB);
            }

            else
            {
                var nouvelleUser = AutoMapper.Mapper.Map<User>(User);
                int idMax = contexteEF.User.Max(p => p.ID);
                nouvelleUser.ID = idMax + 1;

                contexteEF.User.Add(nouvelleUser);
            }

            contexteEF.SaveChanges();

            return RedirectToAction("ListeUser");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            User user = contexteEF.User.Single(p => p.ID == id);
            contexteEF.User.Remove(user);
            contexteEF.SaveChanges();

            return Json(new { Suppression = "OK" });
        }
    }
}