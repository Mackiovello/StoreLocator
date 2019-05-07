using Microsoft.EntityFrameworkCore;

namespace StoreLocator.Model.Database
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Store> Stores { get; set; }
    }
}
