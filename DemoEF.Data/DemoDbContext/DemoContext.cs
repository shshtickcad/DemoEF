using DemoEF.Core;
using DemoEF.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace DemoEF.Data.DemoDbContext
{
    public class DemoContext : DbContext
    {
        public DbSet<FileMaster> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=172.16.3.50;Port=5432;Database=DemoDb;User ID=tickCloudUser;Password=123;Pooling=true;");
        }
    }
}
