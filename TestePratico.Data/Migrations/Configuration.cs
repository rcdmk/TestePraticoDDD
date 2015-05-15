namespace TestePratico.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using TestePratico.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.TestePraticoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
			//AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Context.TestePraticoContext context)
        {
			context.UF.AddOrUpdate(
				new UF { IdUF = 1, Nome = "SP" }
			);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
