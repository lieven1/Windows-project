using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightNav_API.Models.Repositories
{
    public interface IFlightRepository
    {
        Flight GetFlight();
    }
}
