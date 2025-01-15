namespace RecordShop
{
    public interface IAlbumsService
    {
        Album? AddNewAlbum(Album album);
        bool? DeleteAlbumById(int id);
        IEnumerable<Album>? FindAllAlbums();
        Album? FindAlbumById(int id);

        Album? UpdateAlbumById(int id, Album album);
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

        public bool? DeleteAlbumById(int id)
        {
            return _model.DeleteAlbumById(id);
        }

        public IEnumerable<Album>? FindAllAlbums()
        {
            return _model.FindAllAlbums();
        }

        public Album? FindAlbumById(int id)
        {
            return _model.FindAlbumById(id);
        }

        public Album? UpdateAlbumById(int id, Album album)
        {
            return _model.UpdateAlbumById(id, album);   
        }
    }
}
