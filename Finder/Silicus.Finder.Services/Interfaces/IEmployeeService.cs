using Silicus.Finder.Models.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silicus.Finder.Services.Interfaces
{
    public interface IEmployeeService
    {
        void SaveEmployee(Employee newOrganization);
    }
}
