using Silicus.Finder.Models.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silicus.Finder.Web.ViewModel
{
    public class EmployeeViewModel
    {
       
        //[Display(Name = "First Name")]
        public string FirstName { get; set; }


       // [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

       // [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

       // [Display(Name = "Employee Type")]
        public EmployeeType EmployeeType { get; set; }

       // [Display(Name = "Total Experience")]        // placeholder in view for (In Months)
        public int? TotalExperienceInMonths { get; set; }

        //[Display(Name = "Silicus Experience")]
        public int? SilicusExperienceInMonths { get; set; }

       // [Display(Name = "Highest Qualification")]
        //  [Required(ErrorMessage = "Enter your Highest Qualification")]
        public string HighestQualification { get; set; }

        public virtual ICollection<SkillSet> SkillSets { get; set; }

        public int CubicalLocationId { get; set; }      // composite key in Location, Foreign key in Employee
        public virtual CubicalLocation CubicalLocation { get; set; }
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual ICollection<Project> Projects { get; set; } 
    }
}