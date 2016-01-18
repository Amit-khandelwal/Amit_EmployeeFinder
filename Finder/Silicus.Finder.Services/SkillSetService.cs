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

        public List<SkillSet> GetAllSkills()
        {
            var allSkillSet = _context.Query<SkillSet>().ToList();
            return allSkillSet;
        }

        public void DeleteSkillSet(int skillSetId)
        {
            var skillset = _context.Query<SkillSet>().FirstOrDefault(p => p.SkillSetId == skillSetId);
            _context.Delete<SkillSet>(skillset);
        }

        public SkillSet GetSkillSetById(int skillSetId)
        {
            return _context.Query<SkillSet>().Where(skill => skill.SkillSetId == skillSetId).Single();

        }
        public IEnumerable<SkillSet> GetSkillSetListByName(string name)
        {
            var projectListStartsWith = _context.Query<SkillSet>().Where(e => e.Name.Contains(name)).ToList();
            return projectListStartsWith;
        }
    }
}
