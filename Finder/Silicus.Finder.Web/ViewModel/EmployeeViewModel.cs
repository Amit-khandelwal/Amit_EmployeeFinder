using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silicus.Finder.Web.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public int CubicleLocationId { get; set; }      
        public int ContactId { get; set; }
    }
}