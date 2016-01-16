using Silicus.Finder.Entities;
using Silicus.Finder.Models.DataObjects;
using Silicus.Finder.Services.Comparable.EmployeeComparable;
using Silicus.Finder.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Silicus.Finder.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDataContext context;

        public EmployeeService(IDataContextFactory dataContextFactory)
        {
            this.context = dataContextFactory.Create(ConnectionType.Ip);
        }

        public void SaveEmployee(Employee newEmployee)
        {
            context.Add(newEmployee);
        }

        public List<Employee> GetAllEmployees()
        {
            var employeeList = context.Query<Employee>().ToList();
            return employeeList;
        }

        public List<Employee> GetEmployeeByName(string name)
        {
            List<Employee> employeeList = new List<Employee>();
            if (name != null)
            {
                EmployeeSortByName employeeSortByName = new EmployeeSortByName();
                string _name = name.Trim().ToLower();
                employeeList = context.Query<Employee>().ToList()
                .Where((e => e.FullName.ToLower().Contains(_name))).ToList();
                if (employeeList.Count == 0)
                {
                    var empList = context.Query<Employee>().ToList()
                    .Where(e => e.EmployeeId.ToString().Contains(_name)).ToList();
                    empList.Sort(employeeSortByName);

                    return empList;
                }
                employeeList.Sort(employeeSortByName);
            }
            return employeeList;
        }

        public List<Project> GetAllProjects()
        {
            return context.Query<Project>().ToList();
        }

        public Project GetProjectById(int projectId)
        {
            return context.Query<Project>().Where(pro => pro.ProjectId == projectId).First();
        }

        public List<SkillSet> GetAllSkillSets()
        {
            return context.Query<SkillSet>().ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var targetEmployee = context.Query<Employee>().Where(emp => emp.EmployeeId == employeeId).First();
            return targetEmployee;
        }

        public SkillSet GetSkillSetById(int skillSetId)
        {
            return context.Query<SkillSet>().Where(emp => emp.SkillSetId == skillSetId).First();
            
        }

        public void SaveEmployeeProject(EmployeeProjects newEmployeeProject)
        {
            context.Add(newEmployeeProject);
        }

        public void SaveEmployeeSkillSet(EmployeeSkillSet newEmployeeSkillSet)
        {
            context.Add(newEmployeeSkillSet);
        }

        private void DeleteEmployee(Employee selectedEmployee)
        {
            context.Delete(selectedEmployee);
        }

        public void EditEmployee(Employee selectedEmployee)
        {
            var targetEmployee = GetEmployeeById(selectedEmployee.EmployeeId);
            DeleteEmployee(targetEmployee);
            context.Add(selectedEmployee);
        }

        public void AddProjectToEmployee(Employee targetEmployee)
        {

        }


        public Employee GetEmployee(int employeeId)
        {
            var employee = context.Query<Employee>().Where(emp => emp.EmployeeId == employeeId).Single();
            return employee;
        }
    }

}


