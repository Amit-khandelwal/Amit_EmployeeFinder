using Silicus.Finder.Models.DataObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Silicus.Finder.Web.ViewModel
{
    public class ProjectEmployeeDetailsViewModel
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

        [Display(Name = "Total Experience (In Months)")]
        public int? TotalExperienceInMonths { get; set; }

        [Display(Name = "Silicus Experience (In Months)")]
        public int? SilicusExperienceInMonths { get; set; }

        [Display(Name = "Highest Qualification")]
        public string HighestQualification { get; set; }

        public virtual ICollection<SkillSet> SkillSets { get; set; }

        [Display(Name = "Cubical Location")]
        public int CubicleLocationId { get; set; }
        public virtual CubicleLocation CubicalLocation { get; set; }

        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
