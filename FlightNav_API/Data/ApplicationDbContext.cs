using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FlightNav_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlightNav_API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //private ILogger<UserManager<IdentityUser>> logger;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options/*, ILogger<UserManager<IdentityUser>> logger*/)
            : base(options)
        {
            //this.logger = logger;
        }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Flight> Flight { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Flight>().HasData(
            //    new Flight
            //    {
            //        ID = 1,
            //        origin = "Zaventem",
            //        destination = "Rome"
            //    }
            //);

            //Passenger passenger1 = new Passenger
            //{
            //    passengerId = 1,
            //    firstName = "John",
            //    lastName = "Cleese"
            //};
            //Passenger passenger2 = new Passenger
            //{
            //    passengerId = 2,
            //    firstName = "Ron",
            //    lastName = "Weasley"
            //};

            //modelBuilder.Entity<Passenger>().HasData(
            //    passenger1,
            //    passenger2
            //);

            //modelBuilder.Entity<Seat>().HasData(
            //    new
            //    {
            //        seatnumber = 1,
            //        passengerId = 1
            //    },
            //    new
            //    {
            //        seatnumber = 2,
            //        passengerId = 2
            //    }
            //);

            //var initializer = new DataInitializer(this, logger);
            //Task.Run(async () => await initializer.InitializeUsers());
        }
    }
}

