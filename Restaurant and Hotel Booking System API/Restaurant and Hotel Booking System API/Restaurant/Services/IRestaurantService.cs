using Restaurant_and_Hotel_Booking_System_API.Food.Models;
using Restaurant_and_Hotel_Booking_System_API.Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_and_Hotel_Booking_System_API.Restaurant.Services
{
    public interface IRestaurantService
    {
        List<RestaurantsInfo> GetAllRestaurants();
        List<RestaurantsInfo> GetRestaurantsByFoodTypeId(int foodTypeId);
        bool AddUpdateRestaurants(RestaurantRequest restaurantsRequest);

    }
}
