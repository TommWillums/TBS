﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBS.Data;
using TBS.Entities;
using TBS.Repository;

namespace TBS.Controllers
{
    [Produces("application/json")]
    [Route("api/Clubs")]
    public class ClubsController : Controller
    {
        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public IActionResult GetClub([FromRoute] int id)
        {
            var repository = new ClubRepository();
            Club club = repository.GetClub(id);
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

            var repository = new ClubRepository();
            try
            {
                repository.Save(club);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (repository.GetClub(id) == null)
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
            new ClubRepository().Save(club);
            return CreatedAtAction("GetClub", new { id = club.Id }, club);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClub([FromRoute] int id)
        {
            var repository = new ClubRepository();
            Club club = repository.GetClub(id);
            if (club != null)
            {
                club.Deleted = true;
                repository.Save(club);
                return Ok();
            }
            return NotFound();
        }
    }
}