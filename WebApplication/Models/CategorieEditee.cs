using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CategorieEditee
    {
        public int? CategoryID { get; set; }
        [Required(ErrorMessage = "Le nom de catégorie est requis")]
        [StringLength(15, MinimumLength = 3)]
        public string CategoryName { get; set; }

    }
}