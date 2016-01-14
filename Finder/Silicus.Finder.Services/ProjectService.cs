using Silicus.Finder.Entities;
using Silicus.Finder.Models.DataObjects;
using Silicus.Finder.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Silicus.Finder.Services
{
    public class ProjectService :IProjectService
    {
        private readonly IDataContext _context;

        public ProjectService(IDataContextFactory dataContextFactory)
        {
            _context = dataContextFactory.Create(ConnectionType.Ip);
        }

        public int Add(Project Project)
        {
            _context.Add(Project);
            return Project.ProjectId;
        }

        public List<Employee> GetAllEmployee()
        {
            var allEmployeeList = _context.Query<Employee>().ToList();
            return allEmployeeList;
        }

   
    }
}


