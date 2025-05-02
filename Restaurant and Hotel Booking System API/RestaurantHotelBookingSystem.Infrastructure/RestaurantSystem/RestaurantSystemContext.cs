using Microsoft.EntityFrameworkCore;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;

namespace RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem
{
    public class RestaurantSystemContext:DbContext,IRestaurantSystemContext
    {
        public RestaurantSystemContext(DbContextOptions<RestaurantSystemContext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionStringUtility.RestaurantSystemConnectionString);
            }
        }
        public DbSet<People> People { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Foods> Foods { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
    }
}
