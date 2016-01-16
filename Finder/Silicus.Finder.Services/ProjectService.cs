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


        public IEnumerable<Project> GetProjectsList()
        {
            var projectList = _context.Query<Project>().Include(e=>e.Employees).ToList();
            return projectList;
        }


        public IEnumerable<Project> GetProjectsListByName(string name)
        {
            var projectListStartsWith = _context.Query<Project>().Include(e => e.Employees).Where(e => e.ProjectName.StartsWith(name)).ToList();

            var projectListEndsWith = new List<Project>();

            if(projectListStartsWith.Count != 0)
            {
                return projectListStartsWith;
            }
            else if(projectListEndsWith.Count == 0)
            {
                projectListEndsWith = _context.Query<Project>().Include(e => e.Employees).Where(e => e.ProjectName.EndsWith(name)).ToList();

                    if(projectListEndsWith.Count == 0)
                    {
                        return _context.Query<Project>().Include(e => e.Employees).Where(e => e.ProjectId.ToString().Equals(name)).ToList();
                    }                
            }

            return projectListEndsWith;          
        }
    }
}


