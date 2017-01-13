using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class UserEditee
    {
        public int? UserID { get; set; }
        [Required(ErrorMessage = "Le nom est requis")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Le prénom est requis")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
        "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public System.DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "L'adresse est requis")]
        public string Address { get; set; }
        [Required(ErrorMessage = "La ville est requis")]
        public string City { get; set; }
        [Required(ErrorMessage = "Le code postale est requis")]
        public int? PostalCode { get; set; }
        [Required(ErrorMessage = "L'email est requis")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Le pseudo est requis")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Le mot de passe est requis")]
        public string Password { get; set; }
        public string Role { get; set; }

    }
}