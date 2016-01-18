using Silicus.Finder.Entities;
using Silicus.Finder.Models.DataObjects;
using Silicus.Finder.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Silicus.Finder.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IDataContext _context;

        public ProjectService(IDataContextFactory dataContextFactory)
        {
            _context = dataContextFactory.Create(ConnectionType.Ip);
        }

        public int AddProject(Project Project)
        {
            _context.Add(Project);
            return Project.ProjectId;
        }

        public List<Employee> GetAllEmployees()
        {
            var allEmployeeList = _context.Query<Employee>().ToList();
            return allEmployeeList;
        }

        public Employee GetEmployeeById(int? projectId)
        {
            var employee = _context.Query<Employee>().Where(model => model.EmployeeId == projectId).FirstOrDefault();
            return employee;
        }

        public IEnumerable<Project> GetProjectsList()
        {
            //var projectList = _context.Query<Project>().ToList();
            var projectList = _context.Query<Project>().Include(e => e.Employees).ToList();
            return projectList;
        }

        public IEnumerable<Project> GetProjectsListByName(string name)
        {
            var projectListStartsWith = _context.Query<Project>().Include(e => e.Employees).Where(e => e.ProjectName.StartsWith(name)).ToList();

            var projectListEndsWith = new List<Project>();

            if (projectListStartsWith.Count != 0)
            {
                return projectListStartsWith;
            }
            else if (projectListEndsWith.Count == 0)
            {
                projectListEndsWith = _context.Query<Project>().Include(e => e.Employees).Where(e => e.ProjectName.EndsWith(name)).ToList();

                if (projectListEndsWith.Count == 0)
                {
                    return _context.Query<Project>().Include(e => e.Employees).Where(e => e.ProjectId.ToString().Equals(name)).ToList();
                }
            }

            return projectListEndsWith;
        }

        public Project GetProjectById(int? projectId)
        {
            var project = _context.Query<Project>().Where(model => model.ProjectId == projectId).FirstOrDefault();
            return project;
        }

        public List<SkillSet> GetAllSkills()
        {
            var skills = _context.Query<SkillSet>().ToList();
            return skills;
        }

        public SkillSet GetSkillSetById(int? projectId)
        {
            var skillset = _context.Query<SkillSet>().Where(model => model.SkillSetId == projectId).FirstOrDefault();
            return skillset;
        }

        public int UpdateProject(Project Project)
        {
            _context.Update<Project>(Project);
            return Project.ProjectId;
        }

        public IEnumerable<Employee> GetEmployeesAssignedToProject(int projectId)
        {
            var employeesOnProject = _context.Query<Project>().Where(model => model.ProjectId == projectId).First().Employees;
            return employeesOnProject;
        }

        public bool DeallocateEmployyeFromProject(int empId, int projectId)
        {
            Project project = _context.Query<Project>().Where(model => model.ProjectId == projectId).FirstOrDefault();
            Employee employeeToRemove = project.Employees.Where(model => model.EmployeeId == empId).FirstOrDefault();
            var isEmployeeRemoved = project.Employees.Remove(employeeToRemove);
            //  var isEmployeeRemoved = _context.Query<Project>().Where(model => model.ProjectId == projectId).FirstOrDefault().Employees.Remove(employeeToRemove);

            var a = _context.Update<Project>(project);

            if (isEmployeeRemoved)
                return true;
            else
                return false;
        }

        public Project GetProjectDetailsById(int projectId)
        {
            var project = _context.Query<Project>().FirstOrDefault(p => p.ProjectId == projectId);
            return project;
        }

        public void DeleteProject(int projectId)
        {
            var project = _context.Query<Project>().FirstOrDefault(p => p.ProjectId == projectId);
            _context.Delete<Project>(project);
        }
    }
}