using Microsoft.EntityFrameworkCore;
using BookingTourTravelBuzz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Đảm bảo namespace này đúng

namespace BookingTourTravelBuzz.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }       

        public DbSet<Tour> TOURS { get; set; } // Đảm bảo tên này trùng với model
        public object Tour { get; internal set; }
        public DbSet<Area> AREAS { get; set; }
    }
}
