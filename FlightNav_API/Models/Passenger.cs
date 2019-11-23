using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightNav_API.Models
{
    public class Passenger
    {
        public int passengerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
