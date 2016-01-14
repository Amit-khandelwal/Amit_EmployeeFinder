using Silicus.Finder.Models.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silicus.Finder.Services.Comparable.EmployeeComparable
{
    public class EmployeeSortByName : IComparer<Employee>
    {
        public int Compare(Employee employee, Employee _employee)
        {
            return string.Compare(employee.FirstName ,_employee.FirstName);
            throw new NotImplementedException();
        }
    }
}
