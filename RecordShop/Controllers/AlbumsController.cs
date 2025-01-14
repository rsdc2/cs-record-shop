using Microsoft.AspNetCore.Mvc;

namespace RecordShop
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        private IAlbumsService albumsService;
        public AlbumsController(IAlbumsService service)
        {
            albumsService = service;
        }

        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            return Ok(albumsService.GetAllAlbums());
        }

    }
}
