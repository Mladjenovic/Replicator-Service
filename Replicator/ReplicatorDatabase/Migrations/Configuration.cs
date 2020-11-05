namespace ReplicatorDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    [ExcludeFromCodeCoverage]
    internal sealed class Configuration : DbMigrationsConfiguration<ReplicatorDatabase.ReplicatorDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        
        protected override void Seed(ReplicatorDatabase.ReplicatorDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
