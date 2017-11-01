using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBS.Domain;
using TBS.Repository;

namespace TBS.Controllers
{
    [Produces("application/json")]
    [Route("api/Clubs")]
    public class ClubsController : Controller
    {
        private ClubRepository _repository;

        public ClubsController()
        {
            _repository = new ClubRepository();
        }

        // GET: api/Clubs
        [HttpGet]
        public List<Club> GetClubs()
        {
            return _repository.GetClubs().ToList();
        }

        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public IActionResult GetClub([FromRoute] int id)
        {
            Club club = _repository.GetClub(id);
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
            var uow = new UnitOfWork();
            var clubrepo1 = new ClubRepository(uow);
            var courtrepo1 = new CourtRepository(uow);
            try
            {
                clubrepo1.Save(club);
                courtrepo1.Save(new Court() { Name = "TestCourt" });
                uow.Commit();
            }
            catch (Exception ex)
            {
                uow.Rollback();
            }
            return CreatedAtAction("GetClub", new { id = club.Id }, club);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClub([FromRoute] int id)
        {
            Club club = _repository.GetClub(id);
            if (club != null)
            {
                club.Deleted = true;
                _repository.Save(club);
                return Ok();
            }
            return NotFound();
        }

        private bool ClubExists(int id)
        {
            return _repository.GetClub(id) != null;
        }
    }
}