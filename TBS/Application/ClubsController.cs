using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBS.Domain;
using TBS.Service;

namespace TBS.Controllers
{
    [Produces("application/json")]
    [Route("api/Clubs")]
    public class ClubsController : Controller
    {
        private ClubService _service;

        public ClubsController()
        {
            _service = new ClubService();
        }

        // GET: api/Clubs
        [HttpGet]
        public List<Club> GetClubs()
        {
            return _service.GetClubs().ToList();
        }

        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public IActionResult GetClub([FromRoute] int id)
        {
            Club club = _service.GetClub(id);
            if (club == null)
                return NotFound();
            return Ok(club);
        }

        // PUT: api/Clubs/5
        [HttpPut("{id}")]
        public IActionResult PutClub([FromRoute] int id, [FromBody] Club club)
        {
            if (id != club.Id)
                return BadRequest();

            try
            {
                _service.Save(club);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // POST: api/Clubs
        [HttpPost]
        public IActionResult PostClub([FromBody] Club club)
        {
            _service.Save(club);
            return CreatedAtAction("GetClub", new { id = club.Id }, club);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClub([FromRoute] int id)
        {
            var club = _service.GetClub(id);
            if (club == null)
            {
                return NotFound();
            }
            else
            {
                club.Deleted = true;
            }
            _service.Save(club);
            return Ok(club);
        }

        private bool ClubExists(int id)
        {
            return _service.GetClub(id) != null;
        }
    }
}