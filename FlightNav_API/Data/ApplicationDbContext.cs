using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightNav_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightNav_API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Flight> Flight { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flight>().HasData(
                new Flight
                {
                    ID = 1,
                    origin = "Zaventem",
                    destination = "Rome"
                }
            );

            Passenger passenger1 = new Passenger
            {
                passengerId = 1,
                firstName = "John",
                lastName = "Cleese"
            };
            Passenger passenger2 = new Passenger
            {
                passengerId = 2,
                firstName = "Ron",
                lastName = "Weasley"
            };

            modelBuilder.Entity<Passenger>().HasData(
                passenger1,
                passenger2
            );

            modelBuilder.Entity<Seat>().HasData(
                new
                {
                    seatnumber = 1,
                    passengerId = 1
                },
                new
                {
                    seatnumber = 2,
                    passengerId = 2
                }
            );

            Task.Run(async () => { await AddUsersAndRoles(); }).Wait();
        }
        private async Task AddUsersAndRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this), null, null, null, null);
            var role = new IdentityRole { Name = "Staff" };
            if (!roleManager.Roles.Any())
                await roleManager.CreateAsync(role);

            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(this), null, null, null, null, null, null, null, null);
            var passwordHash = new PasswordHasher<IdentityUser>();
            if (!Users.Any())
            {
                var user = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@admin.com",

                };
                user.PasswordHash = passwordHash.HashPassword(user, "12345");
                await userManager.CreateAsync(user);
                //Users.Add(user);
                await userManager.AddToRoleAsync(user, "Staff");
            }
        }
    }
}

