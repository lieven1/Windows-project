using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightNav_API.Models;
using FlightNav_API.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightNav_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatRepository repo;

        public SeatsController(ISeatRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/Seats
        [HttpGet]
        public IEnumerable<Seat> GetSeats()
        {
            return repo.GetSeats();
        }

        // GET: api/Seats/2
        [HttpGet("{id}")]
        public Seat GetSeatById(int id)
        {
            return repo.GetSeatById(id);
        }

        // PUT: api/Seats/2
        [HttpPut("{id}")]
        public ActionResult PutSeat(int id, Seat seat)
        {
            if (id != seat.seatnumber)
            {
                return BadRequest();
            }
            repo.Update(seat);
            repo.SaveChanges();
            return NoContent();
        }

        // POST: api/Seats
        [HttpPost]
        public ActionResult<Seat> PostSeat(Seat seat)
        {
            repo.Add(seat);
            repo.SaveChanges();

            return CreatedAtAction(nameof(GetSeatById), new { id = seat.seatnumber }, seat);
        }

        // DELETE: api/Seat/2
        [HttpDelete("{id}")]
        public ActionResult<Seat> DeleteSeat(int id)
        {
            Seat seat = repo.GetSeatById(id);
            if (seat == null)
            {
                return NotFound();
            }

            repo.Delete(seat);
            return seat;
        }
    }
}
