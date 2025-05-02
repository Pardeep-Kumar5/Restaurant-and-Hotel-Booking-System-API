using Restaurant_and_Hotel_Booking_System_API.Food.Models;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;

namespace Restaurant_and_Hotel_Booking_System_API.Food.Services
{
    public class FoodTypeService(
            IRestaurantSystemContext restaurantSystem) : IFoodTypeService
    {

        public List<FoodTypeInfo> GetAllFoodTypes()
        {
            var foodTypes = restaurantSystem.FoodTypes.ToList();

            var foodTypeList = foodTypes.Select(ft => new FoodTypeInfo
            {
                FoodTypeId = ft.FoodTypeId,
                Name = ft.Name,
                Description = ft.Description,
                Image = ft.Image
            })
                .OrderByDescending(ft=> ft.FoodTypeId)
                .ToList();

            return foodTypeList;
        }

        public FoodTypeInfo GetFoodTypeByName(string foodTypeName)
        {
            var foodType = restaurantSystem.FoodTypes.Where(ft => ft.Name == foodTypeName)
                                            .Select(ft => new FoodTypeInfo
                                            {
                                                FoodTypeId = ft.FoodTypeId,
                                                Name = ft.Name,
                                                Image = ft.Image
                                            }).FirstOrDefault();

            return foodType;
        }
        public FoodTypeInfo GetFoodTypeById(int foodTypId)
        {
            var foodType = restaurantSystem.FoodTypes.Where(ft => ft.FoodTypeId == foodTypId)
                                            .Select(ft => new FoodTypeInfo
                                            {
                                                FoodTypeId = ft.FoodTypeId,
                                                Name = ft.Name,
                                                Description = ft.Description,
                                                Image = ft.Image
                                            }).FirstOrDefault();

            return foodType;
        }

        public bool AddUpdateFoodType(FoodTypeInfo foodTypeRequest)
        {
            if (foodTypeRequest != null)
            {
                var existingFoodType = restaurantSystem.FoodTypes
                                                       .FirstOrDefault(f => f.FoodTypeId == foodTypeRequest.FoodTypeId);

                if (existingFoodType != null)
                {
                    existingFoodType.Name = foodTypeRequest.Name;
                    existingFoodType.Description = foodTypeRequest.Description;
                    existingFoodType.Image = foodTypeRequest.Image;
                    restaurantSystem.Update(existingFoodType);
                }
                else
                {
                    var newFoodType = new FoodType
                    {
                        Name = foodTypeRequest.Name,
                        Description = foodTypeRequest.Description,
                        Image = foodTypeRequest.Image
                    };

                    restaurantSystem.FoodTypes.Add(newFoodType);
                }
                restaurantSystem.SaveChanges();
                return true;
            }
            return false;
        }

        
    }
}
