using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightNav_API.Models
{
    public class Seat
    {
        [Key]
        public int seatnumber { get; set; }
        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; }
    }
}
