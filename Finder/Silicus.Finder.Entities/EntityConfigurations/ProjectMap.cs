using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Silicus.Finder.Models.DataObjects;

namespace Silicus.Finder.Entities.EntityConfigurations
{
    internal class ProjectMap :EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            HasKey(o => o.ProjectId);

            Property(p => p.ProjectId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable(TableSettings.Projects, TableSettings.DefaultSchema);
        }
    }
}



