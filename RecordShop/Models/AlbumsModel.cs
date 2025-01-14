namespace RecordShop
{
    

    public interface IAlbumsModel
    {
        List<Album> GetAllAlbums();
    }

    public class AlbumsModel : IAlbumsModel
    {
        private static Album greatAlbum = new Album(id: 1, title: "Great album", artist: "Great artist");
        private static List<Album> testAlbums = new()
        {
            greatAlbum
        };
        public List<Album> GetAllAlbums()
        {
            return testAlbums;
        }
    }
}
