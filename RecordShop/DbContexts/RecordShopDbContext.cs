using Microsoft.EntityFrameworkCore;

namespace RecordShop
{
    public class RecordShopDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public RecordShopDbContext(DbContextOptions<RecordShopDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase(databaseName: "RecordShopDB");
        //}
    }
}
