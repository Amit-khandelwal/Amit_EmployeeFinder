using Silicus.Finder.Entities;
using Silicus.Finder.Models.DataObjects;
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

        public void SaveEmployee(Employee newOrganization)
        {
            context.Add(newOrganization);
            //context.SaveChanges();
        }
    }
}
