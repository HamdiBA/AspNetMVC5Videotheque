using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class FactureEditee
    {

        public int? FactureID { get; set; }
        public string CustomerName { get; set; }
        public int? Article1ID { get; set; }
        public string ArticleName1 { get; set; }
        public string Catégorie1 { get; set; }
        public int? Quantity1 { get; set; }
        public int? Price1 { get; set; }
        public Nullable<int> Article2ID { get; set; }
        public string ArticleName2 { get; set; }
        public string Catégorie2 { get; set; }
        public Nullable<int> Quantity2 { get; set; }
        public Nullable<int> Price2 { get; set; }
        public string User { get; set; }
        public System.DateTime FactureDate { get; set; }

    }
}