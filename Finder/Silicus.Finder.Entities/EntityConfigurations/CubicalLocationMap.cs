using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Silicus.Finder.Models.DataObjects;


namespace Silicus.Finder.Entities.EntityConfigurations
{
    internal class CubicalLocationMap : EntityTypeConfiguration<CubicalLocation>
    {
        public CubicalLocationMap()
        {
            HasKey(o => o.CubicalLocationId);

            Property(p => p.CubicalLocationId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable(TableSettings.CubicalLocations, TableSettings.DefaultSchema);

        }
    }
}