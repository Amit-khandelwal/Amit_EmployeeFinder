using Silicus.Finder.Models.DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Silicus.Finder.Web.ViewModel
{
    public class ProjectListViewModel
    {
        [Key]
        [Display(Name = "Code/ID")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Project Name can't be blank")]
        [StringLength(100, ErrorMessage = "Project Name  should contain less than 100 characters")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Display(Name = "Type")]
        public ProjectType ProjectType { get; set; }

        [Display(Name = "Engagement")]
        public EngagementType EngagementType { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        public Status Status { get; set; }

        [Display(Name = "Expected End Date")]
        [DataType(DataType.Date)]
        public DateTime? ExpectedEndDate { get; set; }

        [Display(Name = "Engagement Manager")]
        public int? EngagementManagerId { get; set; }

        [Display(Name = "Project Manager")]
        public int? ProjectManagerId { get; set; }
    }
}