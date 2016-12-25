using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ArticleEditee
    {
        public int? ID { get; set; }
        [Required]
        public string Nom_art { get; set; }
        public string Categorie { get; set; }
        public string Genre { get; set; }
        public int? Quantite { get; set; }
        public double? Prix { get; set; }
        public Nullable<System.DateTime> Date_ajout { get; set; }

        
    }
}