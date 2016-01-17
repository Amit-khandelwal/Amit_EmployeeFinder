using Silicus.Finder.Models.DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Silicus.Finder.Web.ViewModel
{
    public class ProjectViewModel
    {
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Project Type")]
        public ProjectType ProjectType { get; set; }

        [Display(Name = "Engagement Type")]
        public EngagementType EngagementType { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Expected End_Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ExpectedEndDate { get; set; }

        [Display(Name = "Actual End_Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ActualEndDate { get; set; }
    }
}