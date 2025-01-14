namespace RecordShop
{
    public interface IAlbumsService
    {
        IEnumerable<Album> GetAllAlbums();
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
            return _model.GetAllAlbums();
        }
    }
}
