using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silicus.Finder.Models.DataObjects
{
    public class Employee
    {
        public Employee()
        {
            //Projects = new HashSet<Project>();
        }
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
        public string FullName { get {return FirstName+" "+ LastName;} }

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

        public virtual ICollection<EmployeeSkillSet> EmployeeSkillSets { get; set; }

        [ForeignKey("CubicleLocation")]
        public int CubicleLocationId { get; set; }      // composite key in Location, Foreign key in Employee
        public virtual CubicleLocation CubicleLocation { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        //[NotMapped]
        ////public int[] ProjectId { get; set; }
        //public virtual ICollection<Project> Projects { get; set; }   // rename at the time of mapping otherwise Project_ProjectId column will get created

        public virtual ICollection<EmployeeProjects> EmployeeProjects { get; set; }

        [Display(Name = "Manager Recommendation")]
        [StringLength(200)]
        public string ManagerRecommendation { get; set; }
        
    }
}
