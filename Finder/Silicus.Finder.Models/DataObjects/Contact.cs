using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silicus.Finder.Models.DataObjects
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        public string SkypeId { get; set; }
        public string EmailId { get; set; } // have to make it unique 
        public string PhoneNumber { get; set; }
        public int? MobileNumber { get; set; }

       // public virtual Employee Employee { get; set; }
    }
}