using Microsoft.EntityFrameworkCore;
using Restaurant_and_Hotel_Booking_System_API.Food.Models;
using Restaurant_and_Hotel_Booking_System_API.Restaurant.Model;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;

namespace Restaurant_and_Hotel_Booking_System_API.Restaurant.Services
{
    public class RestaurantService(
        IRestaurantSystemContext restaurantSystem) : IRestaurantService
    {
        public List<RestaurantsInfo> GetAllRestaurants()
        {
            var restaurants = restaurantSystem.Restaurants
                                                .Include(x=> x.FoodType)
                                                .ToList();

            var restaurantList = restaurants.Select(r => new RestaurantsInfo
            {
                RestaurantId = r.RestaurantId,
                Name = r.Name,
                Rating = r.Rating,
                Location = r.Location,
                Image = r.Image,
                FoodType = r.FoodType
                
            })
                .OrderByDescending(r=> r.RestaurantId)
                .ToList();

            return restaurantList;
        }

        public List<RestaurantsInfo> GetRestaurantsByFoodTypeId(int foodTypeId)
        {
            var restaurants = restaurantSystem.Restaurants.
                Where(r=> r.FoodTypeId == foodTypeId)
                .Include(x=>x.FoodType)
                .ToList();

            var restaurantList = restaurants.Select(r => new RestaurantsInfo
            {
                RestaurantId = r.RestaurantId,
                Name = r.Name,
                Rating = r.Rating,
                Location = r.Location,
                Image = r.Image,
                FoodType = r.FoodType
            }).ToList();

            return restaurantList;
        }

        public bool AddUpdateRestaurants(RestaurantRequest restaurantsRequest)
        {
            var existingRestaurants = restaurantSystem.Restaurants
                                        .FirstOrDefault(f => f.RestaurantId == restaurantsRequest.RestaurantId);

            if (existingRestaurants != null)
            {
                existingRestaurants.Name = restaurantsRequest.Name;
                existingRestaurants.Image = restaurantsRequest.Image;
                existingRestaurants.Rating = restaurantsRequest.Rating;
                existingRestaurants.Location = restaurantsRequest.Location;
                existingRestaurants.FoodTypeId = restaurantsRequest.FoodTypeId;

                restaurantSystem.Restaurants.Update(existingRestaurants);
            }
            else
            {
                var newFood = new Restaurants
                {
                    Name = restaurantsRequest.Name,
                    Image = restaurantsRequest.Image,
                    Rating = restaurantsRequest.Rating,
                    Location = restaurantsRequest.Location,
                    FoodTypeId = restaurantsRequest.FoodTypeId,
                };

                restaurantSystem.Restaurants.Add(newFood);
            }

            restaurantSystem.SaveChanges();
            return true;
        }
    }
}
