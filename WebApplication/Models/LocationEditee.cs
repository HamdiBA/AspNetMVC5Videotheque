using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class LocationEditee
    {
        public int? ID { get; set; }
        public int? ArticleID { get; set; }
        public int? ClientID { get; set; }
        public int? UserID { get; set; }
        public System.DateTime? DateLocation { get; set; }
        public System.DateTime? DateRetour { get; set; }
        public string EtatLocation { get; set; }

        public virtual Article Article { get; set; }
        public virtual Client Client { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}