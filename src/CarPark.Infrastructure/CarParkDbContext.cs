using CarPark.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CarPark.Infrastructure
{
    public class CarParkDbContext : DbContext
    {
        public CarParkDbContext(DbContextOptions<CarParkDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
