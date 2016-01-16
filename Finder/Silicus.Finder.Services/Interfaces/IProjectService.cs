using Silicus.Finder.Models.DataObjects;
using System.Collections.Generic;
namespace Silicus.Finder.Services.Interfaces
{
    public interface IProjectService
    {
        int AddProject(Project Project);
        int UpdateProject(Project Project);
        List<Project> GetAllProjects();
        Project GetProjectById(int? id);
        List<SkillSet> GetAllSkills();
        SkillSet GetSkillSetById(int? id);
        List<Employee> GetAllEmployee();
        Employee GetEmployeeById(int? id);
       
    }
}
