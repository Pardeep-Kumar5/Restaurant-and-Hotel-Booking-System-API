using Microsoft.EntityFrameworkCore;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem
{
    public interface IRestaurantSystemContext:IDbContext
    {
        DbSet<People> People { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<FoodType> FoodTypes { get; set; }
        DbSet<Foods> Foods { get; set; }
        DbSet<Restaurants> Restaurants { get; set; }
        DbSet<ExceptionLog> ExceptionLogs { get; set; }
    }
}
