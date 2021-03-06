﻿using System.Data.Entity;

namespace Silicus.Finder.Entities.Initializer
{
    public class FinderIpDropCreateDatabaseIfModelChangesInitializer : DropCreateDatabaseIfModelChanges<FinderIpDataContext>
    {
        protected override void Seed(FinderIpDataContext context)
        {
            BaseDatabaseInitializer.Seed(context);
        }
    }
}
