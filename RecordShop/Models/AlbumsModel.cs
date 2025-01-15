using Microsoft.EntityFrameworkCore;

namespace RecordShop
{
    

    public interface IAlbumsModel
    {
        Album? AddNewAlbum(Album album);
        bool? DeleteAlbumById(int id);
        IEnumerable<Album>? FindAllAlbums();
        Album? FindAlbumById(int id);
        int? FindFirstUnusedId();

        Album? UpdateAlbumById(int id, Album album);
    }

    public class AlbumsModel : IAlbumsModel
    {
        static RecordShopDbContext? _dbContext;
        public AlbumsModel(RecordShopDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public Album? AddNewAlbum(Album album)
        {
            var albumToAdd = new Album() { Title = album.Title, Artist =  album.Artist };
            if (_dbContext == null) return null;
            _dbContext.Add(album);
            _dbContext.SaveChanges();
            return _dbContext.Albums.FirstOrDefault(a => a.Title == album.Title && a.Artist == album.Artist);
        }

        public bool? DeleteAlbumById(int id)
        {
            if (_dbContext == null) return null;
            var album = FindAlbumById(id);
            if (album == null) return null;

            var returnAlbum = _dbContext.Remove(album);
            _dbContext.SaveChanges();

            var foundAlbum = FindAlbumById(id);
            return foundAlbum == null ? true : false;
        }

        public IEnumerable<Album>? FindAllAlbums()
        {
            if (_dbContext == null) return null;
            return _dbContext.Albums;
        }

        public int? FindFirstUnusedId()
        {
            if (_dbContext == null) return null;
            if (_dbContext.Albums.ToList().Count == 0) return 0;
            return _dbContext.Albums.Max(album => album.Id) + 1;
        }

        public Album? FindAlbumById(int id)
        {
            if (_dbContext == null) return null;
            var album = _dbContext.Albums.FirstOrDefault(album => album.Id == id);
            return album;
        }

        public Album? UpdateAlbumById(int id, Album album)
        {
            if (_dbContext == null) return null;

            var existingAlbum = FindAlbumById(id);
            if (existingAlbum == null)
            {
                return null;
            }
            album.Id = id;
            _dbContext.Albums.Remove(existingAlbum);
            _dbContext.Albums.Add(album);
            _dbContext.SaveChanges();
            return FindAlbumById(id);
        }
    }
}
