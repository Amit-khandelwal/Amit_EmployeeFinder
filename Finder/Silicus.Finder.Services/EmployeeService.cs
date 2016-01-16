﻿using Silicus.Finder.Entities;
using Silicus.Finder.Models.DataObjects;
using Silicus.Finder.Services.Comparable.EmployeeComparable;
using Silicus.Finder.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

       public List<Employee> GetEmployee()
        {
            var emp = context.Query<Employee>().ToList();
               return emp;
        }

        public List<Employee> GetEmployeeByName(string name)
      {
            List<Employee> _employeeList = new List<Employee>();
            if(name != null)
            {
                string _name = name.Trim();
                _employeeList = context.Query<Employee>().ToList().Where((e => e.FirstName.Contains(_name))).ToList();
                EmployeeSortByName _employeeSortByName = new EmployeeSortByName();
                _employeeList.Sort(_employeeSortByName);
            }
            return _employeeList;
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
            return context.Query<Employee>().Where(emp => emp.EmployeeId == employeeId).First();
            
        }

        public SkillSet GetSkillSetById(int skillSetId)
        {
            return context.Query<SkillSet>().Where(emp => emp.SkillSetId == skillSetId).First();
            
        }

        public void EditEmployee(Employee selectedEmployee)
        {
           // context.Update(selectedEmployee.Contact);
            context.Update<Employee>(selectedEmployee);
        }

    }
}
