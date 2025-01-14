namespace RecordShop
{
    public interface IAlbumsService
    {
        IEnumerable<Album> GetAllAlbums();
        Album? GetAlbumById(int id);
    }

    public class AlbumsService : IAlbumsService
    {
        private IAlbumsModel _model;

        public AlbumsService(IAlbumsModel model)
        {
            _model = model;
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return _model.FindAllAlbums();
        }

        public Album? GetAlbumById(int id)
        {
            return _model.FindAlbumById(id);
        }
    }
}
