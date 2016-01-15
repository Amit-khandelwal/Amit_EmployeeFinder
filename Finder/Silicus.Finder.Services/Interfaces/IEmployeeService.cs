using Silicus.Finder.Models.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silicus.Finder.Services.Interfaces
{
   public interface IEmployeeService
    {
       List<Employee> GetEmployeeByName(string name);
       List<Employee> GetEmployee();
       void SaveEmployee(Employee newEmployee);
       void AddProjectToEmployee(Employee targetEmployee);
       Employee GetEmployeeById(int employeeId);
       List<Project> GetAllProjects();
       List<SkillSet> GetAllSkillSets();
       Project GetProjectById(int projectId);
       void SaveEmployeeProject(EmployeeProjects newEmployeeProject);
       void SaveEmployeeSkillSet(EmployeeSkillSet newEmployeeSkillSet);
    }
}
