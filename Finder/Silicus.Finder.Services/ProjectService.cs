using Silicus.Finder.Entities;
using Silicus.Finder.Services.Interfaces;

namespace Silicus.Finder.Services
{
    public class ProjectService :IProjectService
    {
        private readonly IDataContext context;

        public ProjectService(IDataContextFactory dataContextFactory)
        {
            this.context = dataContextFactory.Create(ConnectionType.Ip);
        }
    }
}


