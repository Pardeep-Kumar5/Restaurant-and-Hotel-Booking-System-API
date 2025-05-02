using Microsoft.Extensions.DependencyInjection;
using Restaurant_and_Hotel_Booking_System_API.Common.Exceptions;
using Restaurant_and_Hotel_Booking_System_API.Food.Services;
using Restaurant_and_Hotel_Booking_System_API.PeopleAuthentication;
using Restaurant_and_Hotel_Booking_System_API.Peoples.Services;
using Restaurant_and_Hotel_Booking_System_API.Restaurant.Services;
using Restaurant_and_Hotel_Booking_System_API.Users.Services;
using SubmittalTransmittal.ApplicationCore;

namespace Restaurant_and_Hotel_Booking_System_API
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationCoreDependencies(this IServiceCollection services)
        {
            services.AddHttpClient<HttpService>();

            _=services
            .AddScoped<IUserService, UserService>()
            .AddScoped<ICurrentUserInfoService, CurrentUserInfoService>()
            .AddScoped<IPeopleService, PeopleService>()
            .AddScoped<IErrorLogger, ErrorLogger>()
            .AddScoped<IFoodsServices, FoodServices>()
            .AddScoped<IFoodTypeService, FoodTypeService>()
            .AddScoped<IPeopleAuthenticationService, PeopleAuthenticationService>()
            .AddScoped<IRestaurantService, RestaurantService>();
            return services;
        }
    }
}
