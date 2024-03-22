using Eurosong.Data;
using Eurosong.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eurosong.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController : ControllerBase
    {
        private IEurosongDataContext _data;
        public SongsController(IEurosongDataContext data)
        {
            _data = data;
        }

        [HttpGet]
        //[Authorize(Policy = "BasicAuthentication", Roles ="admin")]
        public ActionResult<IEnumerable<Song>> Get()
        {
            return Ok(_data.GetSongs());
        }

        [HttpGet("{id}")]
        public ActionResult<Song> Get(int id)
        {
            Song s = _data.GetSong(id);
            if (s != null) return Ok(s);
            return NotFound("Song not found! Try another ID!");
        }

        [HttpGet("{id}/votes")]
        public ActionResult<IEnumerable<Song>> GetVotes(int id)
        {
            IEnumerable<Vote> votes = _data.GetVotes(id);
            if (votes.Count() > 0) return Ok(votes);
            return NotFound("No votes found for this song!");
        }

        [HttpGet("{id}/points")]
        public ActionResult<int> GetPoints(int id)
        {
            return Ok(_data.GetPoints(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody]Song song)
        {
            _data.AddSong(song);
            return Ok("Hooray");
        }

        [HttpPut]
        public ActionResult Update(int id, [FromBody] Song song)
        {
            Song s = _data.GetSong(id);
            if (s != null) _data.UpdateSong(id, song);
            return NotFound("Song not found! Try another ID!");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _data.DeleteSong(id);
            return Ok("Hooray");
        }
    }
}
