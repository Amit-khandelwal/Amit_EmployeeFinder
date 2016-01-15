using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silicus.Finder.Models.DataObjects
{
    public class EmployeeSkillSet
    {
        [Key]
        public int EmployeeSkillSetId { get; set; }
        public int EmployeeId { get; set; }
        public int SkillSetId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("SkillSetId")]
        public virtual SkillSet SkillSet { get; set; }
    }
}
