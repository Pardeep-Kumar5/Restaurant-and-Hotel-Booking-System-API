using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantHotelBookingSystem.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddDbContext<IRestaurantSystemContext, RestaurantSystemContext>
                (option =>option.UseSqlServer(ConnectionStringUtility.RestaurantSystemConnectionString));

            return services;
        }
    }
}
