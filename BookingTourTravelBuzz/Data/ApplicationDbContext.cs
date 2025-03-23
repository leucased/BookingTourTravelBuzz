using Microsoft.EntityFrameworkCore;
using BookingTourTravelBuzz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BookingTourTravelBuzz.Models.Guides;
using BookingTourTravelBuzz.Models.Tours; // Đảm bảo namespace này đúng

namespace BookingTourTravelBuzz.Data
{
    public class ApplicationDbContext : IdentityDbContext<Customer>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }       

        public DbSet<Tour> TOURS { get; set; } // Đảm bảo tên này trùng với model
        public object Tour { get; internal set; }
        public DbSet<Area> AREAS { get; set; }
        public DbSet<Admin> ADMIN { get; set; }
        public DbSet<Booking> BOOKINGS { get; internal set; }

        public DbSet<Guide> GUIDES { get; set; }
    }
}
