using Microsoft.EntityFrameworkCore;

namespace StoreLocator.Model.Database
{
    public class StoresContext : DbContext
    {
        public StoresContext(DbContextOptions<StoresContext> options) : base(options)
        {
        }

        public DbSet<Store> Stores { get; set; }
    }
}
