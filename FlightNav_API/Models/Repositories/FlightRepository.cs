using FlightNav_API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightNav_API.Models.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private ApplicationDbContext _context;
        private DbSet<Flight> _flight;

        public FlightRepository(ApplicationDbContext context)
        {
            _context = context;
            _flight = context.Flight;
        }

        public Flight GetFlight()
        {
            return _flight.FirstOrDefault();
        }
    }
}
