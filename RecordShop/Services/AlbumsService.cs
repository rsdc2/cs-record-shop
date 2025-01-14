namespace RecordShop
{
    public interface IAlbumsService
    {
        IEnumerable<Album> FindAllAlbums();
        Album? FindAlbumById(int id);

        Album? AddNewAlbum(Album album);
    }

    public class AlbumsService : IAlbumsService
    {
        private IAlbumsModel _model;

        public AlbumsService(IAlbumsModel model)
        {
            _model = model;
        }

        public Album? AddNewAlbum(Album album)
        {
            return _model.AddNewAlbum(album);
        }

        public IEnumerable<Album> FindAllAlbums()
        {
            return _model.FindAllAlbums();
        }

        public Album? FindAlbumById(int id)
        {
            return _model.FindAlbumById(id);
        }
    }
}
