using CustomerBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerBooking.Data
{
    public class CustomerBookingContext : DbContext
    {
        public CustomerBookingContext(DbContextOptions<CustomerBookingContext> options) : base(options) { }

        public DbSet<Booking> Booking { get; set; }
    }
}
