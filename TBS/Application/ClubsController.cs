using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBS.Data;
using TBS.Domain;
using TBS.Repository;

namespace TBS.Controllers
{
    [Produces("application/json")]
    [Route("api/Clubs")]
    public class ClubsController : Controller
    {
        private readonly IRepository<Club> _repository;

        public ClubsController(IRepository<Club> repository)
        {
            _repository = repository;
        }

        // GET: api/Clubs
        [HttpGet]
        public List<Club> GetClubs()
        {
            return _repository.GetAll().ToList();
        }

        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public IActionResult GetClub([FromRoute] int id)
        {
            Club club = _repository.Get(id);
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
                    _repository.Save(club);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_repository.Get(id) == null)
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
            _repository.Save(club);
            return CreatedAtAction("GetClub", new { id = club.Id }, club);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClub([FromRoute] int id)
        {
                Club club = _repository.Get(id);
                if (club != null)
                {
                    club.Deleted = true;
                    _repository.Save(club);
                    return Ok();
                }
                return NotFound();

        }
    }
}