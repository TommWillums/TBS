using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBS.Domain;
using TBS.Facade;

namespace TBS.Controllers
{
    [Produces("application/json")]
    [Route("api/Clubs")]
    public class ClubsController : Controller
    {
        private ClubFacade _facade;

        public ClubsController()
        {
            _facade = new ClubFacade();
        }

        // GET: api/Clubs
        [HttpGet]
        public List<Club> GetClubs()
        {
            return _facade.GetClubs().ToList();
        }

        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public IActionResult GetClub([FromRoute] int id)
        {
            Club club = _facade.GetClub(id);
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
                _facade.Save(club);
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
            _facade.Save(club);
            return CreatedAtAction("GetClub", new { id = club.Id }, club);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClub([FromRoute] int id)
        {
            Club club = _facade.GetClub(id);
            if (club != null)
            {
                club.Deleted = true;
                _facade.Save(club);
                return Ok();
            }
            return NotFound();
        }

        private bool ClubExists(int id)
        {
            return _facade.GetClub(id) != null;
        }
    }
}