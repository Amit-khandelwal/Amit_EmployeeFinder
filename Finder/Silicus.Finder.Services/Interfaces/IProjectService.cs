using Silicus.Finder.Models.DataObjects;
using System.Collections.Generic;
namespace Silicus.Finder.Services.Interfaces
{
    public interface IProjectService
    {
        int AddProject(Project Project);

        int UpdateProject(Project Project);

        Project GetProjectById(int? projectId);

        List<SkillSet> GetAllSkills();

        SkillSet GetSkillSetById(int? projectId);

        List<Employee> GetAllEmployees();

        IEnumerable<Project> GetProjectsList();

        IEnumerable<Project> GetProjectsListByName(string name);

        Employee GetEmployeeById(int? projectId);

        IEnumerable<Employee> GetEmployeesAssignedToProject(int projectId);
        
        bool DeallocateEmployyeFromProject(int empId, int projectId);

        Project GetProjectDetailsById(int projectId);
     
        void DeleteProject(int projectId);
    }
}