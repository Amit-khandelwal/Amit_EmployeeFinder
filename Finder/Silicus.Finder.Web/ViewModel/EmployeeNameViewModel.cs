using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Silicus.Finder.Web.ViewModel
{
    public class EmployeeNameViewModel
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name can't be blank")]
        [StringLength(20, ErrorMessage = "First Name should contain less than 20 characters")]
        public string FirstName { get; set; }
    }
}