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
    [ScaffoldColumn(false)]
        public int ContactId { get; set; }

        [Display(Name="Skype Id")]
        public string SkypeId { get; set; }
        [Display(Name = "Email Id")]
        public string EmailId { get; set; } // have to make it unique 
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Mobile Number")]
        public int? MobileNumber { get; set; }

       // public virtual Employee Employee { get; set; }
    }
}