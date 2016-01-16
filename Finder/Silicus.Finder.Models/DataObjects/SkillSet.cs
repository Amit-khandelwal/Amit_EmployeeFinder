using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silicus.Finder.Models.DataObjects
{
    public class SkillSet
    {
        [Key]
        public int SkillSetId { get; set; }

        [Required(ErrorMessage = "Name can't be blank")]
        [StringLength(30, ErrorMessage = "Name should contain less than 30 characters")]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        //public virtual ICollection<EmployeeSkillSet> EmployeeSkillSets { get; set; }
    }
}