using DeathValley.Models;

namespace DeathValley.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DeathValley.Models.ParamCacheDatasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DeathValley.Models.ParamCacheDatasContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Params.AddOrUpdate(
              p => p.ParamId,
              new Param { CoefficientA = 8, CoefficientB = 2, CoefficientC = 3, RangeFrom = -5, RangeTo = 5, Step = 1},
              new Param { CoefficientA = 2, CoefficientB = 3, CoefficientC = 4, RangeFrom = -2, RangeTo = 2, Step = 1 },
              new Param { CoefficientA = -3, CoefficientB = 5, CoefficientC = 10, RangeFrom = -3, RangeTo = 3, Step = 1 }
            );
            //
        }
    }
}
