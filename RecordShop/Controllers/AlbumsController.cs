using Microsoft.AspNetCore.Mvc;

namespace RecordShop
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        private IAlbumsService _service;
        public AlbumsController(IAlbumsService service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAlbumById(int id) => _service.DeleteAlbumById(id) switch
        {
            true => NoContent(),
            false => StatusCode(410),
            null => NotFound()
        };

        [HttpGet("{id}")]
        public IActionResult GetAlbumById(int id) => _service.FindAlbumById(id) switch
        {
            null => NotFound(),
            Album album => Ok(album)
        };

        [HttpGet]
        public IActionResult GetAllAlbums() => _service.FindAllAlbums() switch
        {
            null => StatusCode(500),
            IEnumerable<Album> albums => Ok(albums)
        };

        [HttpPost]
        public IActionResult PostAlbum(Album album)
        {
            var returnAlbum = _service.AddNewAlbum(album);
            return returnAlbum == null ? NotFound() : Ok(returnAlbum);
        }

    }
}
