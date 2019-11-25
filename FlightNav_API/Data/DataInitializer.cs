using FlightNav_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlightNav_API.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

            //var passwordHash = new PasswordHasher<IdentityUser>();
            //var userValidators = new List<UserValidator<IdentityUser>>();
            //userValidators.Add(new UserValidator<IdentityUser>());
            //var passwordValidators = new List<PasswordValidator<IdentityUser>>();
            //passwordValidators.Add(new PasswordValidator<IdentityUser>());
            //var keyNormalizer = new UpperInvariantLookupNormalizer();
            //var errors = new IdentityErrorDescriber();
            //_userManager = new UserManager<IdentityUser>(
            //    new UserStore<IdentityUser>(_context),null,passwordHash,userValidators, passwordValidators, keyNormalizer, errors, null, logger);
        }

        public async Task Initialize()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                InitializeFlightData();
                await InitializeUsers();
            }
        }

        public void InitializeFlightData()
        {
            var flight = new Flight()
            {
                origin = "Zaventem",
                destination = "Rome"
            };
            var passenger1 = new Passenger()
            {
                firstName = "John",
                lastName = "Cleese"
            };
            var passenger2 = new Passenger()
            {
                firstName = "Ron",
                lastName = "Weasley"
            };
            var seat1 = new Seat()
            {
                Passenger = passenger1
            };
            var seat2 = new Seat()
            {
                Passenger = passenger2
            };

            _context.Flight.Add(flight);
            _context.Passengers.Add(passenger1);
            _context.Passengers.Add(passenger2);
            _context.Seats.Add(seat1);
            _context.Seats.Add(seat2);

            _context.SaveChanges();
        }

        public async Task InitializeUsers()
        {
            var user = new IdentityUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com"
            };
            //user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, "12345");
            await _userManager.CreateAsync(user, "P@ssword1");
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "staff"));

            _context.SaveChanges();
        }
    }
}
