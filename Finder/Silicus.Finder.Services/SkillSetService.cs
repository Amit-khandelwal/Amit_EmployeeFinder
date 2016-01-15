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
    public class SkillSetService : ISkillSetService
    {
        private readonly IDataContext _context;

        public SkillSetService(IDataContextFactory dataContextFactory)
        {
            _context = dataContextFactory.Create(ConnectionType.Ip);
        }

        public void Add(SkillSet skillSet)
        {
            _context.Add(skillSet);
        } 
    }
}
