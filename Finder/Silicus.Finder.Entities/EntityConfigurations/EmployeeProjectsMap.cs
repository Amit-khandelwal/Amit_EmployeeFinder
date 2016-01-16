using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Silicus.Finder.Models.DataObjects;

namespace Silicus.Finder.Entities.EntityConfigurations
{
    internal class EmployeeProjectsMap : EntityTypeConfiguration<EmployeeProjects>
    {
        public EmployeeProjectsMap()
        {
            HasKey(o => o.EmployeeProjectsId);

            Property(p => p.EmployeeProjectsId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable(TableSettings.EmployeeProjects, TableSettings.DefaultSchema);

        }

    }
}
