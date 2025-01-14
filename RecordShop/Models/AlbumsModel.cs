using Microsoft.EntityFrameworkCore;

namespace RecordShop
{
    

    public interface IAlbumsModel
    {
        IEnumerable<Album> GetAllAlbums();
    }

    public class AlbumsModel : IAlbumsModel
    {
        RecordShopDbContext _dbContext;
        public AlbumsModel(RecordShopDbContext dbContext)
        {
            _dbContext = dbContext;
            var greatAlbum = new Album(id: 1, title: "Great album", artist: "Great artist");
            dbContext.Albums.Add(greatAlbum);
            dbContext.SaveChanges();
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return _dbContext.Albums;
        }
    }
}
