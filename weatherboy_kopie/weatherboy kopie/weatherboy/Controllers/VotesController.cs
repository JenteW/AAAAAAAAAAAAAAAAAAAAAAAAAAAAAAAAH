using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using weatherboy.Data;
using weatherboy.Models;

namespace weatherboy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private IAnonymousEurosongDataContext _data;
        public VotesController(IAnonymousEurosongDataContext data)
        {
            _data = data;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Vote>> Get()
        {
            return Ok(_data.GetVote());
        }
        [HttpPost]
        public ActionResult Post([FromBody] Vote vote)
        {
            _data.AddVote(vote);
            return Ok("Vote added");
        }
        [HttpGet("{id}")]
        public ActionResult<Vote> Get(int id)
        {
            return Ok(_data.GetVoteBySongId(id));
        }
    }
}
