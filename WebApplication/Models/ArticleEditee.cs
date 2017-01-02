using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ArticleEditee
    {
        public int? ArticleID { get; set; }
        public string ArticleName { get; set; }
        public int? CategoryID { get; set; }
        public int? GenreID { get; set; }
        public string Duration { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
        "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public System.DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public double? Note { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public System.DateTime? DateAdded { get; set; }


    }
}