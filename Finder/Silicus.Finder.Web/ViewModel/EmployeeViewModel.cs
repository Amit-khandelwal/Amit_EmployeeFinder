using Silicus.Finder.Models.DataObjects;
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

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Employee Type")]
        public EmployeeType EmployeeType { get; set; }

        [Display(Name = "Total Experience")]
        public int? TotalExperienceInMonths { get; set; }

        [Display(Name = "Silicus Experience")]
        public int? SilicusExperienceInMonths { get; set; }

        [Display(Name = "Highest Qualification")]
        public string HighestQualification { get; set; }

        [Display(Name = "Skill Set")]
        public virtual ICollection<SkillSet> SkillSets { get; set; }

        [Display(Name = "Cubicle Location")]
        public virtual CubicleLocation CubicleLocation { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}