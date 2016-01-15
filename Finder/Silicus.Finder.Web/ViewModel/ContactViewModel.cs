using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silicus.Finder.Web.ViewModel
{
    public class ContactViewModel
    {
        public string SkypeId { get; set; }
        public string EmailId { get; set; } 
        public string PhoneNumber { get; set; }
        public int? MobileNumber { get; set; }
    }
}