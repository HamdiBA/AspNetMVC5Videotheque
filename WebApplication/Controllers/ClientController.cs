using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ClientController : Controller
    {
        private LocatMe_BDEntities contexteEF = new LocatMe_BDEntities();

        // GET: Cleint
        public ActionResult ListeClient()
        {
            List<Client> clients = contexteEF.Client.ToList();
            return View(clients);
        }

        [HttpGet]
        public ActionResult EditClient(int? id)
        {
            if (id.HasValue)
            {
                Client client = contexteEF.Client.Single(p => p.ID == id);
                ClientEditee clientEditee = AutoMapper.Mapper.Map<ClientEditee>(client);
                return View(clientEditee);
            }
            else
            {
                // Pas d'ID : création
                return View(new ClientEditee());
            }
        }

        [HttpPost]
        public ActionResult EditClient(ClientEditee client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }

            if (client.ID.HasValue)
            {
                Client clientDB = contexteEF.Client.Single(p => p.ID == client.ID);
                clientDB = AutoMapper.Mapper.Map<ClientEditee, Client>(client, clientDB);
            }

            else
            {
                var nouvelleClient = AutoMapper.Mapper.Map<Client>(client);
                //int idMax = contexteEF.Client.Max(p => p.ID);
                //nouvelleClient.ID = idMax + 1;

                contexteEF.Client.Add(nouvelleClient);
            }

            contexteEF.SaveChanges();

            return RedirectToAction("ListeClient");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            Client client = contexteEF.Client.Single(p => p.ID == id);
            contexteEF.Client.Remove(client);
            contexteEF.SaveChanges();

            return Json(new { Suppression = "OK" });
        }
    }
}