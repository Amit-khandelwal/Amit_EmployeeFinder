using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silicus.Finder.Models.DataObjects
{
    public class EmployeeProjects
    {
        [Key]
        public int EmployeeProjectsId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        //[ForeignKey("EmployeeId")]
        //public virtual Employee Employee { get; set; }

        //[ForeignKey("ProjectId")]
        //public virtual Project Project { get; set; }
    }
}
