using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Silicus.Finder.Models.DataObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silicus.Finder.Models.DataObjects
{
    public class Project
    {

        public Project()
        {
            this.Employees = new HashSet<Employee>();
            this.SkillSets = new HashSet<SkillSet>();
        }


        [Key]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Project Name can't be blank")]
        [StringLength(100, ErrorMessage = "Project Name  should contain less than 100 characters")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [StringLength(250, ErrorMessage = "Description should contain less than 250 characters")]
        public string Description { get; set; }

        [Display(Name = "Project Type")]
        public ProjectType ProjectType { get; set; }

        [Display(Name = "Engagement Type")]
        public EngagementType EngagementType { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Expected End_Date")]
        [DataType(DataType.Date)]
        public DateTime? ExpectedEndDate { get; set; }

        [Display(Name = "Actual End_Date")]
        [DataType(DataType.Date)]
        public DateTime? ActualEndDate { get; set; }

        [Display(Name = "Engagement Manager")]
        public int? EngagementManagerId { get; set; }
      
        [Display(Name = "Project Manager")]
        public int? ProjectManagerId { get; set; }

        [StringLength(150, ErrorMessage = "Additional Notes should contain less than 150 characters")]
        [Display(Name = "Additional Notes")]
        public string AdditionalNotes { get; set; }
       
        public virtual ICollection<SkillSet> SkillSets { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}