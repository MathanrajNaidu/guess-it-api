namespace GuessItApi.Migrations
{
    using GuessItApi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuessItApi.Models.GuessItApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuessItApi.Models.GuessItApiContext context)
        {
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
            context.HallOfFames.AddOrUpdate(
                x => x.Id,
                new HallOfFame { Name = "Player 1", NumberOfAttempts = 100, PlayTime = (new DateTime()).ToUniversalTime() }
            );
        }
    }
}
