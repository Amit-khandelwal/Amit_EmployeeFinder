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

        public Employee GetEmployeeById(int? id)
        {
            var employee=_context.Query<Employee>().Where(model => model.EmployeeId == id).FirstOrDefault();
            return employee;
        }


        public List<Project> GetAllProjects()
        {
            var projects=_context.Query<Project>().ToList(); 
            return projects;
        }


        public Project GetProjectById(int? id)
        {
             var project= _context.Query<Project>().Where(model => model.ProjectId == id).FirstOrDefault();
             return project;
        }



        public List<SkillSet> GetAllSkills()
        {
            var skills=_context.Query<SkillSet>().ToList();
            return skills;
        }


        public SkillSet GetSkillSetById(int? id)
        {
            var skillset=_context.Query<SkillSet>().Where(model => model.SkillSetId == id).FirstOrDefault();
            return skillset;
        }
    }
}


