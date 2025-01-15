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
        public IActionResult PostAlbum(Album album) => _service.AddNewAlbum(album) switch
        {
            null => StatusCode(500),
            Album albumAdded => Ok(albumAdded)
        };

        [HttpPut("{id}")]
        public IActionResult PutAlbum(int id, Album album) => _service.UpdateAlbumById(id, album) switch
        {
            null => NotFound(),
            Album updatedAlbum => Ok(updatedAlbum)
        };

    }
}
