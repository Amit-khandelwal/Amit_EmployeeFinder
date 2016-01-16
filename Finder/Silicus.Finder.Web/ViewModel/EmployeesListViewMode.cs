
using Silicus.Finder.Models.DataObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silicus.Finder.Web.ViewModel
{
    public class EmployeesListViewMode
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name can't be blank")]
        [StringLength(20, ErrorMessage = "First Name should contain less than 20 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "Middle Name should contain less than 20 characters")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name can't be blank")]
        [StringLength(20, ErrorMessage = "Last Name should contain less than 20 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }

        [Required(ErrorMessage = "Please select Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Employee Type")]
        public EmployeeType EmployeeType { get; set; }

        [Display(Name = "Total Experience")]        // placeholder in view for (In Months)
        public int? TotalExperienceInMonths { get; set; }

        [Display(Name = "Silicus Experience")]
        public int? SilicusExperienceInMonths { get; set; }

        [Display(Name = "Highest Qualification")]
        //  [Required(ErrorMessage = "Enter your Highest Qualification")]
        public string HighestQualification { get; set; }

        public List<SkillSet> skillSetList = new List<SkillSet>();

        public virtual ICollection<SkillSet> SkillSets { get; set; }

        [ForeignKey("CubicalLocation")]
        public int CubicalLocationId { get; set; }      // composite key in Location, Foreign key in Employee
        public virtual CubicalLocation CubicalLocation { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public virtual ICollection<Project> Projects { get; set; }   // rename at the time of mapping otherwise Project_ProjectId column will get created


    }
}