using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ClientEditee
    {
        public int? CustomerID { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Le numéro d'identité est requis")]
        public int? IdentityCard { get; set; }
        public string Civility { get; set; }
        [Required(ErrorMessage = "Le nom est requis")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Le prénom est requis")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "La date de naissance est requis")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
       "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public System.DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "L'adresse est requis")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Le code postale est requis")]
        public int? PostalCode { get; set; }
        [Required(ErrorMessage = "La ville est requis")]
        public string City { get; set; }
        [Required(ErrorMessage = "Le numéro de téléphone est requis")]
        [DataType(DataType.PhoneNumber)]
        public int? Phone { get; set; }
        [Required(ErrorMessage = "L'email est requis")]
        public string Email { get; set; }
    }
}