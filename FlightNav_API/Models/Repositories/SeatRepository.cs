using FlightNav_API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightNav_API.Models.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Seat> _seats;

        public SeatRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _seats = dbContext.Seats;
        }

        public void Add(Seat seat)
        {
            _seats.Add(seat);
        }

        public void Delete(Seat seat)
        {
            _seats.Remove(seat);
        }

        public Seat GetSeatById(int id)
        {
            return _seats.Include(s => s.Passenger).SingleOrDefault(s => s.seatnumber == id);
        }

        public IEnumerable<Seat> GetSeats()
        {
            return _seats.Include(s => s.Passenger);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Seat seat)
        {
            _seats.Update(seat);
        }
    }
}
