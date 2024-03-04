using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using weatherboy.Data;
using weatherboy.Models;

namespace weatherboy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private IAnonymousEurosongDataContext _data;
        public ArtistController(IAnonymousEurosongDataContext data)
        {
            _data = data;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Artist>> Get()
        {
            return Ok(_data.GetArtist());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Artist artist)
        {
            _data.AddArtist(artist);
            return Ok("Artist added");
        }

        [HttpGet("{id}")]
        public ActionResult<Artist> Get(int id)
        {
            return Ok(_data.GetArtistById(id));
        }
        [HttpGet("{id}/songs")]

        public ActionResult<Song> GetSongsByArtistId(int id)
        {
            return Ok(_data.getSongsByArtistID(id));
        }

    }
}
