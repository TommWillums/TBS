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
        private readonly IRepository<Club> _context;

        public ClubsController(IRepository<Club> context)
        {
            _context = context;
        }

        // GET: api/Clubs
        [HttpGet]
        public IEnumerable<Club> GetClubs()
        {
            return _context.GetAll();
        }

        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClub([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var club = await _context.GetAll().SingleOrDefaultAsync(m => m.Id == id);

            if (club == null)
            {
                return NotFound();
            }

            return Ok(club);
        }

        // PUT: api/Clubs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClub([FromRoute] int id, [FromBody] Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != club.Id)
            {
                return BadRequest();
            }

            //_context.Entry(club).State = EntityState.Modified;

            try
            {
                await _context.SaveChanges(club);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clubs
        [HttpPost]
        public async Task<IActionResult> PostClub([FromBody] Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(club);
            await _context.SaveChanges(club);

            return CreatedAtAction("GetClub", new { id = club.Id }, club);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var club = _context.Get(m => m.Id == id);
            if (club == null)
            {
                return NotFound();
            }
            else
                _context.Delete(club);

            //_context.Remove(club);
            //await _context.SaveChangesAsync();

            return Ok(club);
        }

        private bool ClubExists(int id)
        {
            return _context.GetAll(m => m.Id == id).Count() > 0;
        }
    }
}