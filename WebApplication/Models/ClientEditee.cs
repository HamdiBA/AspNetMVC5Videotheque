using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ClientEditee
    {
        public int? ID { get; set; }
        public string Titre { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public int? Code_Postal { get; set; }
        public string Ville { get; set; }
        public int? Numéro_Téléphone { get; set; }
        public string Adresse_de_messagerie { get; set; }
    }
}