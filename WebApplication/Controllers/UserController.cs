﻿using System;
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

        [Authorize(Roles = "Administrateur")]
        // GET: Cleint
        public ActionResult ListeUser()
        {
            List<Utilisateur> users = contexteEF.Utilisateur.ToList();
            return View(users);
        }

        [Authorize(Roles = "Administrateur")]
        [HttpGet]
        public ActionResult EditUser(int? id)
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

        [Authorize(Roles = "Administrateur")]
        [HttpPost]
        public ActionResult EditUser(UserEditee user)
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

            else
            {
                var nouvelleUser = AutoMapper.Mapper.Map<Utilisateur>(user);
                //int idMax = contexteEF.Utilisateur.Max(u => u.UserID);
                //nouvelleUser.UserID = idMax + 1;

                contexteEF.Utilisateur.Add(nouvelleUser);
            }

            contexteEF.SaveChanges();

            return RedirectToAction("ListeUser");
        }

        [Authorize(Roles = "Administrateur")]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Utilisateur user = contexteEF.Utilisateur.Single(u => u.UserID == id);
            contexteEF.Utilisateur.Remove(user);
            contexteEF.SaveChanges();

            return Json(new { Suppression = "OK" });
        }
    }
}