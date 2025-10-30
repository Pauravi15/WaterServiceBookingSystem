using WaterServiceBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace WaterServiceBookingSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ServiceBooking> ServiceBookings { get; set; }

    }
}
