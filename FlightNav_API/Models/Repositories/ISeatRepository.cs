using FlightNav_API.Models;
using System.Collections.Generic;

namespace FlightNav_API.Models.Repositories
{
    public interface ISeatRepository
    {
        IEnumerable<Seat> GetSeats();
        Seat GetSeatById(int id);
        void Update(Seat seat);
        void SaveChanges();
        void Add(Seat seat);
        void Delete(Seat seat);
    }
}