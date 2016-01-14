using Silicus.Finder.Models.DataObjects;
using System.Collections.Generic;
namespace Silicus.Finder.Services.Interfaces
{
    public interface IProjectService
    {
        int Add(Project Project);
        List<Employee> GetAllEmployee();
        IEnumerable<Project> GetProjectsList();
    }
}
