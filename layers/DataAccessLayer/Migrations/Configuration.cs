﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Contcrete.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //migration üzerinde değişiklik yapabilmemizi sağlar
        }

        protected override void Seed(DataAccessLayer.Contcrete.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
