using Microsoft.EntityFrameworkCore;

namespace RecordShop
{
    public class RecordShopDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public RecordShopDbContext(DbContextOptions<RecordShopDbContext> options) : base(options) 
        {
            //var greatAlbum = new Album(id: 1, title: "Great album", artist: "Great artist");
            //Albums.Add(greatAlbum);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var greatAlbum = new Album(id: 1, title: "Great album", artist: "Great artist");
        //    modelBuilder.Entity<Album>().HasData(greatAlbum);
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase(databaseName: "RecordShopDB");
        //}
    }
}
