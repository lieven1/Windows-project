using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightNav_API.Models
{
    public class Flight
    {
        public int ID { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public DateTime ETA { get; set; }
    }
}
