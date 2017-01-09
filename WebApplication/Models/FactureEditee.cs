using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class FactureEditee
    {
        public int? FactureID { get; set; }
        public int? LocationID { get; set; }
        public string CompnayName { get; set; }
        public string CompanyAdDress { get; set; }

        public virtual Location Location { get; set; }
    }


}