using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ClientEditee
    {
        public int? CustomerID { get; set; }
        public string Civility { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int? PostalCode { get; set; }
        public string City { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
    }
}