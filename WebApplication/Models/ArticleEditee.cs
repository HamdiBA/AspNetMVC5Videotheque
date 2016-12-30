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
        public string Nom_art { get; set; }
        public int? CategorieID { get; set; }
        public int? GenreID { get; set; }
        public int? Quantite { get; set; }
        public double? Prix { get; set; }
        public System.DateTime? Date_ajout { get; set; }


    }
}