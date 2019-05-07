using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StoreLocator.Model.Database;
using System;

namespace StoreLocator.Data
{
    // This method is called by Entity Framework Core
    // when running the initial migration to create
    // the StoresContext in the database
    public class StoresContextFactory : IDesignTimeDbContextFactory<StoresContext>
    {
        public StoresContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("STORE_LOCATOR_DB");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("The environment variable STORE_LOCATOR_DB is not set");
            }

            var builder = new DbContextOptionsBuilder<StoresContext>()
                .UseSqlite(connectionString);
            return new StoresContext(builder.Options);
        }
    }
}
