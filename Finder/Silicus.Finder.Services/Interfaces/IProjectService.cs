using Silicus.Finder.Models.DataObjects;
using System.Collections.Generic;
namespace Silicus.Finder.Services.Interfaces
{
    public interface IProjectService
    {
        int Add(Project Project);
      
        Project GetProjectById(int? id);
        List<SkillSet> GetAllSkills();
        SkillSet GetSkillSetById(int? id);
        List<Employee> GetAllEmployee();
        IEnumerable<Project> GetProjectsList();
        IEnumerable<Project> GetProjectsListByName(string name);
        Employee GetEmployeeById(int? id);
       
    }
}
