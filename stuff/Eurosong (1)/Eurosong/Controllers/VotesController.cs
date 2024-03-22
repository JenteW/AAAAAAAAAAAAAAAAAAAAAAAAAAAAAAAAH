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
    public class VotesController : ControllerBase
    {
        private IEurosongDataContext _data;
        public VotesController(IEurosongDataContext data)
        {
            _data = data;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vote>> Get()
        {
            return Ok(_data.GetVotes());
        }

        [HttpGet("{id}")]
        public ActionResult<Song> Get(int id)
        {
            Vote v = _data.GetVote(id);
            if (v != null) return Ok(v);
            return NotFound("Vote not found! Try another ID!");
        }

        [HttpPost]
        public ActionResult Post([FromBody]Vote vote)
        {
            _data.AddVote(vote);
            return Ok("Hooray");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _data.DeleteVote(id);
            return Ok("Hooray");
        }

        [HttpPut]
        public ActionResult Update(int id, [FromBody] Vote vote)
        {
            Vote v = _data.GetVote(id);
            if (v != null) _data.UpdateVote(id, vote);
            return NotFound("Vote not found! Try another ID!");
        }
    }
}
