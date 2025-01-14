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

        [HttpGet("{id}")]
        public IActionResult GetAlbumById(int id)
        {
            var album = _service.GetAlbumById(id);
            return album == null ? NotFound() : Ok(album);
        }

        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            return Ok(_service.GetAllAlbums());
        }

    }
}
