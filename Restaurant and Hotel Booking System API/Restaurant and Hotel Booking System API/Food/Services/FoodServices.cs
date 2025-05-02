using Microsoft.EntityFrameworkCore;
using Restaurant_and_Hotel_Booking_System_API.Food.Models;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;

namespace Restaurant_and_Hotel_Booking_System_API.Food.Services
{
    public class FoodServices(IRestaurantSystemContext restaurantSystem) : IFoodsServices
    {
        public List<FoodInfo> GetAllFoodsList()
        {
            var foods = restaurantSystem.Foods
                             .Include(ft => ft.FoodType)
                             .Include(r => r.Restaurants)
                             .ToList();

            var foodsLists = foods.Select(f => new FoodInfo
            {
                FoodId = f.FoodId,
                Name = f.Name,
                Price = f.Price,
                Image = f.Image,
                IsVeg = f.IsVeg,
                Rating = f.Rating,
                Description = f.Description,
                FoodType = f.FoodType,
                Restaurants = f.Restaurants,
            })
                .OrderByDescending(f=>f.Restaurants.RestaurantId)
                .ToList();

            return foodsLists;
        }

        public List<FoodInfo> GetAllFoodsListByRestaurantId(int restaurantId)
        {
            var foods = restaurantSystem.Foods
                             .Where(x=> x.RestaurantId == restaurantId)
                             .Include(ft => ft.FoodType)
                             .Include(r => r.Restaurants)
                             .ToList();

            var foodsLists = foods.Select(f => new FoodInfo
            {
                FoodId = f.FoodId,
                Name = f.Name,
                Price = f.Price,
                Image = f.Image,
                IsVeg = f.IsVeg,
                Description = f.Description,
                Rating = f.Rating,
                FoodType = f.FoodType,
                Restaurants = f.Restaurants,
            })
              .ToList();

            return foodsLists;
        }

        public List<FoodInfo> GetAllFoodListByFoodTypeId(int foodTypeId)
        {
            var foods = restaurantSystem.Foods
                         .Include(ft => ft.FoodType)
                         .Include(r =>r.Restaurants)
                         .Where(f => f.FoodTypeId == foodTypeId)
                         .ToList();

            var foodsList = foods.Select(f => new FoodInfo
            {
                FoodId = f.FoodId,
                Name = f.Name,
                Price = f.Price,
                Image = f.Image,
                IsVeg = f.IsVeg,
                Description = f.Description,
                Rating = f.Rating,
                FoodType = f.FoodType,
                Restaurants  = f.Restaurants
            }).ToList();

            return foodsList;
        }
        public bool AddUpdateFood(AddUpdaterestaurantsRequest restaurantsRequest)
        {
            var existingFood = restaurantSystem.Foods
                                        .FirstOrDefault(f => f.FoodId == restaurantsRequest.FoodId);

            if (existingFood != null)
            {
                existingFood.Name = restaurantsRequest.Name;
                existingFood.Price = restaurantsRequest.Price;
                existingFood.Image = restaurantsRequest.Image;
                existingFood.IsVeg = restaurantsRequest.isVeg;
                existingFood.Description = restaurantsRequest.Description;
                existingFood.Rating = restaurantsRequest.Rating;
                existingFood.FoodTypeId = restaurantsRequest.FoodTypeId;
                existingFood.RestaurantId = restaurantsRequest.RestaurantId;

                restaurantSystem.Foods.Update(existingFood);
            }
            else
            {
                var newFood = new Foods
                {
                    Name = restaurantsRequest.Name,
                    Price = restaurantsRequest.Price,
                    Image = restaurantsRequest.Image,
                    IsVeg = restaurantsRequest.isVeg,
                    Description = restaurantsRequest.Description,
                    Rating = restaurantsRequest.Rating,
                    FoodTypeId = restaurantsRequest.FoodTypeId,
                    RestaurantId = restaurantsRequest.RestaurantId
            };

                restaurantSystem.Foods.Add(newFood);
            }

            restaurantSystem.SaveChanges();
            return true;
        }
    }
}
