using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class GenreEditee
    {
        public int? GenreID { get; set; }
        [Required(ErrorMessage = "Le nom de genre est requis")]
        [StringLength(15, MinimumLength = 3)]
        public string GenreName { get; set; }
    }
}