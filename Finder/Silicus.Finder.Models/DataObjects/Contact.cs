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

        [StringLength(15)]
        public string Skype { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; } // have to make it unique 

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Mobile can't be blank")]
        [Display(Name = "Mobile Number")]
        public int? MobileNumber { get; set; }

       // public virtual Employee Employee { get; set; }
    }
}