using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using weatherboy.Data;
using weatherboy.Models;

namespace weatherboy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private IAnonymousEurosongDataContext _data;

        public SongsController(IAnonymousEurosongDataContext data)
        {
            _data = data;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Song>> Get()
        {
            return Ok(_data.GetSongs());
        }
        [HttpPost]
        public ActionResult Post([FromBody] Song song)
        {
            _data.AddSong(song);
            return Ok("hoe ray ;)");
        }
        [HttpGet ("{id}")]
        public ActionResult<Song> Get(int id)
        {
            return Ok(_data.GetSongById(id));
        }

        [HttpGet("{id}/votes")]
        public ActionResult<Vote> GetVotesBySongId(int id)
        {
            return Ok(_data.getVoteBySongID(id));
        }
    }
}
