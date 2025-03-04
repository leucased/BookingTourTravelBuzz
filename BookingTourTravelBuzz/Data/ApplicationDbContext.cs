using Microsoft.EntityFrameworkCore;
using BookingTourTravelBuzz.Models; // Đảm bảo namespace này đúng

namespace BookingTourTravelBuzz.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tour> TOURS { get; set; } // Đảm bảo tên này trùng với model
        public object Tour { get; internal set; }
        public DbSet<Area> AREAS { get; set; }
    }
}
