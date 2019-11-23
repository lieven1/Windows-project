using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightNav_API.Data;
using FlightNav_API.Models;
using FlightNav_API.Models.Repositories;

namespace FlightNav_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository repo;

        public FlightController(IFlightRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/Flight
        [HttpGet]
        public Flight GetFlight()
        {
            return repo.GetFlight();
        }
    }
}
