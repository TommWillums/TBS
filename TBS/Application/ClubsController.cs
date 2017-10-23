using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private readonly IRepository<Club> _repository;

        public ClubsController(IRepository<Club> repository)
        {
            _repository = repository;
        }

        // GET: api/Clubs
        [HttpGet]
        public IEnumerable<Club> GetClubs()
        {
            return _repository.GetAll();
        }

        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public IActionResult GetClub([FromRoute] int id)
        {
            var club = _repository.GetAll(m => m.Id == id);
            if (club == null)
            {
                return NotFound();
            }

            return Ok(club);
        }

        // PUT: api/Clubs/5
        [HttpPut("{id}")]
        public IActionResult PutClub([FromRoute] int id, [FromBody] Club club)
        {
            if (id != club.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.SaveChanges(club);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ClubExists(id))
                //{
                //    return NotFound();
                //}
                //else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Clubs
        [HttpPost]
        public IActionResult PostClub([FromBody] Club club)
        {
            _repository.Add(club);
            _repository.SaveChanges(club);
            return CreatedAtAction("GetClub", new { id = club.Id }, club);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub([FromRoute] int id)
        {
            var club = _repository.Get(m => m.Id == id);
            if (club == null)
            {
                return NotFound();
            }
            else
                _repository.Delete(club);
            //await _repository.SaveChanges();

            return Ok(club);
        }

        //private bool ClubExists(int id)
        //{
        //    return _repository.GetAll(m => m.Id == id).Count() > 0;
        //}
    }
}