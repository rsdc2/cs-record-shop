using Microsoft.EntityFrameworkCore;

namespace RecordShop
{
    public class RecordShopDbContext : DbContext
    {
        private readonly IConfiguration Configuration;  
        public DbSet<Album> Albums { get; set; }
        public RecordShopDbContext(DbContextOptions<RecordShopDbContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var constring = Configuration.GetConnectionString("RecordShop");
                optionsBuilder.UseSqlServer(constring);

            }
        }
    }
}
