using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Silicus.Finder.Models.DataObjects;

namespace Silicus.Finder.Models.DataObjects
{
    public class Project
    {
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

        public EngagementType EngagementType { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Expected End_Date")]
        public DateTime? ExpectedEndDate { get; set; }

        [Display(Name = "Actual End_Date")]
        public DateTime? ActualEndDate { get; set; }

        // [Required(ErrorMessage = "Engagement Manager Id can't be blank")]
        [Display(Name = "Project Name")]
        public int? EngagementManagerId { get; set; }

        // [Required(ErrorMessage = "Project Manager Id can't be blank")]
        [Display(Name = "Project Manager Id")]
        public int? ProjectManagerId { get; set; }

        [StringLength(150, ErrorMessage = "Additional Notes should contain less than 150 characters")]
        [Display(Name = "Additional Notes")]
        public string AdditionalNotes { get; set; }

        //[Display(Name = "Technology Id")]
        //public int TechnologyId { get; set; }    // have some issue with Technology

        public virtual ICollection<SkillSet> SkillSets { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}