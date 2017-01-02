using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class LocationEditee
    {
        public int? LocationID { get; set; }
        public int? ArticleID { get; set; }
        public int? CustomerID { get; set; }
        public int? UserID { get; set; }
        public System.DateTime? DateLocation { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
        "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public System.DateTime? DateBack { get; set; }
        public string EtatLocation { get; set; }

        public virtual Article Article { get; set; }
        public virtual Client Client { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}