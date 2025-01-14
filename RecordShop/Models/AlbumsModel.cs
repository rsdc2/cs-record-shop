using Microsoft.EntityFrameworkCore;

namespace RecordShop
{
    

    public interface IAlbumsModel
    {
        IEnumerable<Album> FindAllAlbums();
        Album? FindAlbumById(int id);
        int FindFirstUnusedId();
        Album? AddNewAlbum(Album album);
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
        public Album? AddNewAlbum(Album album)
        {
            var albumId = FindFirstUnusedId();
            album.Id = albumId;
            _dbContext.Add(album);
            _dbContext.SaveChanges();
            return _dbContext.Albums.FirstOrDefault(album => album.Id == albumId);
        }

        public IEnumerable<Album> FindAllAlbums()
        {
            return _dbContext.Albums;
        }

        public int FindFirstUnusedId()
        {
            if (_dbContext.Albums.ToList().Count == 0)
            {
                return 0;
            } 
            return _dbContext.Albums.Max(album => album.Id) + 1;
        }

        public Album? FindAlbumById(int id)
        {
            var album = _dbContext.Albums.FirstOrDefault(album => album.Id == id);
            return album;
        }
    }
}
