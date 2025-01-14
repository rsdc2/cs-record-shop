using Microsoft.EntityFrameworkCore;

namespace RecordShop
{
    

    public interface IAlbumsModel
    {
        IEnumerable<Album> FindAllAlbums();
        Album? FindAlbumById(int id);
    }

    public class AlbumsModel : IAlbumsModel
    {
        static RecordShopDbContext _dbContext;
        public AlbumsModel(RecordShopDbContext dbContext)
        {
            //if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" && _dbContext == null)
            //{

            //}
            _dbContext = dbContext;

        }

        public IEnumerable<Album> FindAllAlbums()
        {
            return _dbContext.Albums;
        }

        public Album? FindAlbumById(int id)
        {
            var album = _dbContext.Albums.FirstOrDefault(album => album.Id == id);
            return album;
        }


    }
}
