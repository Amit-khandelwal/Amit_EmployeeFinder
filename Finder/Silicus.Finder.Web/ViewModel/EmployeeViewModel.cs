using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Silicus.Finder.Web.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        //[Required(ErrorMessage = "First Name can't be blank")]
        //[StringLength(20, ErrorMessage = "First Name should contain less than 20 characters")]
        //public string FullName{ get; set; }
        //public string FirstName { get; set; }
        //public string MiddleName { get; set; }
        //public string LastName { get; set; }
        //public string FullName { get { return FirstName + " " + LastName; } }
        //public int CubicleLocationId { get; set; }      
        //public int ContactId { get; set; }
    }
}