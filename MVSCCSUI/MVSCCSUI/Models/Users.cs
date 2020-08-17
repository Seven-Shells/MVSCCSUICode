using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVSCCSUI.Models
{
    public class DropDown
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Users
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
        public char RegisteredAsPOC { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int Country { get; set; }
        public string Telephone { get; set; }
        public string CompanyName { get; set; }
        public string FullAddress { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public bool RememberMe { get; set; }
       public System.Web.Mvc.SelectList sb { get; set; }
    }
}