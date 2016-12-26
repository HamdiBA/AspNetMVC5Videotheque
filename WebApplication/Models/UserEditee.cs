using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class UserEditee
    {
        public int? ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public System.DateTime? Date_de_naissance { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public int? Code_Postal { get; set; }
        public string Adresse_de_messagerie { get; set; }
        public string Pseudo { get; set; }
        public string Mot_de_passe { get; set; }
        public string Role { get; set; }
    }
}