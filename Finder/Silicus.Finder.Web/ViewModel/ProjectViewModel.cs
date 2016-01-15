using Silicus.Finder.Models.DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Silicus.Finder.Web.ViewModel
{
    public class ProjectViewModel
    {
        [Display(Name = "Project Id")]
        public int ProjectId { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Project Type")]
        public ProjectType ProjectType { get; set; }

        [Display(Name = "Engagement Type")]
        public EngagementType EngagementType { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Expected End_Date")]
        public DateTime? ExpectedEndDate { get; set; }

        [Display(Name = "Actual End_Date")]
        public DateTime? ActualEndDate { get; set; }

        [Display(Name = "Project Name")]
        public int? EngagementManagerId { get; set; }

        [Display(Name = "Project Manager Id")]
        public int? ProjectManagerId { get; set; }

        [Display(Name = "Additional Notes")]
        public string AdditionalNotes { get; set; }

        public virtual ICollection<SkillSet> SkillSets { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}