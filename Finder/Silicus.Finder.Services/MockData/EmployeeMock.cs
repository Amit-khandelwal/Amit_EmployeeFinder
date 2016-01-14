using Silicus.Finder.Models.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silicus.Finder.Services.MockData
{
    public class EmployeeMock
    {
       
        public List<Employee> EmployeeData()
        {
            List<Employee> empList = new List<Employee>()
            {
                new Employee( )
                {
                   EmployeeId =1,
                   // FullName="abc",
                        MiddleName="patil",
                        LastName = "Gupta",
                        TotalExperienceInMonths = 10,
                        SilicusExperienceInMonths =1,
                        HighestQualification="BE",
                        CubicalLocationId =1,
                        ContactId=1
                },

            };

            return empList;
        }

    }
}
 