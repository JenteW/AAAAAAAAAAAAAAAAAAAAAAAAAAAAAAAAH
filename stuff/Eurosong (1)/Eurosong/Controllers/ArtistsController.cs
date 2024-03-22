using Eurosong.Data;
using Eurosong.Models;
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
    public class ArtistsController : ControllerBase
    {
        private IEurosongDataContext _data;
        public ArtistsController(IEurosongDataContext data)
        {
            _data = data;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Artist>> Get()
        {
            return Ok(_data.GetArtists());
        }

        [HttpGet("{id}")]
        public ActionResult<Artist> Get(int id)
        {
            Artist a = _data.GetArtist(id);
            if (a != null) return Ok(a);
            return NotFound("Artist not found! Try another ID!");
        }

        [HttpPut]
        public ActionResult Update(int id, [FromBody] Artist artist)
        {
            Artist a = _data.GetArtist(id);
            if (a != null) _data.UpdateArtist(id, artist);
            return NotFound("Artist not found! Try another ID!");
        }

        [HttpGet("{id}/songs")]
        public ActionResult<IEnumerable<Song>> GetSongs(int id)
        {
            IEnumerable<Song> songs = _data.GetSongs(id);
            if (songs.Count() > 0) return Ok(songs);
            return NotFound("No songs found for this artist!");
        }

        [HttpPost]
        public ActionResult Post([FromBody]Artist artist)
        {
            _data.AddArtist(artist);
            return Ok("Hooray");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _data.DeleteArtist(id);
            return Ok("Hooray");
        }
    }
}
