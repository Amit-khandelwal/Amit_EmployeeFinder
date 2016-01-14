using Silicus.Finder.Entities;
using Silicus.Finder.Models.DataObjects;
using Silicus.Finder.Services.Interfaces;
using Silicus.Finder.Services.MockData;
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

       public List<Employee> GetEmployee()
        {
          //  var emp = context.Query<Employee>().ToList();
            var emp = new EmployeeMock().EmployeeData();
               return emp;
        }

        public List<Employee> GetEmployeeByName(string name)
        {
            string _name = name.Trim();
            List<Employee> _employeeList = new List<Employee>();
            _employeeList = new EmployeeMock().EmployeeData().Where(e => e.FirstName.Contains(_name)).ToList();
            //_employeeList = context .Query<Employee>().ToList().Where(e => e.FirstName.Contains(_name)).ToList();
            return _employeeList;
        }
    }
}
