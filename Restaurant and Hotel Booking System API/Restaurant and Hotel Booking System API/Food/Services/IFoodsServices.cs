using Restaurant_and_Hotel_Booking_System_API.Food.Models;

namespace Restaurant_and_Hotel_Booking_System_API.Food.Services
{
    public interface IFoodsServices
    {
        List<FoodInfo> GetAllFoodsList();
        List<FoodInfo> GetAllFoodsListByRestaurantId(int restaurantId);
        List<FoodInfo> GetAllFoodListByFoodTypeId(int foodTypeId);
        bool AddUpdateFood(AddUpdaterestaurantsRequest restaurantsRequest);
    }
}
    