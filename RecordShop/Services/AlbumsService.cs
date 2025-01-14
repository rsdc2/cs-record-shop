namespace RecordShop
{
    public interface IAlbumsService
    {
        List<Album> GetAllAlbums();
    }

    public class AlbumsService : IAlbumsService
    {
        private IAlbumsModel _model;

        public AlbumsService(IAlbumsModel model)
        {
            _model = model;
        }

        public List<Album> GetAllAlbums()
        {
            return _model.GetAllAlbums();
        }
    }
}
