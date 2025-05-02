using Restaurant_and_Hotel_Booking_System_API.Food.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_and_Hotel_Booking_System_API.Food.Services
{
    public interface IFoodTypeService
    {
        List<FoodTypeInfo> GetAllFoodTypes();
        FoodTypeInfo GetFoodTypeByName(string foodTypeName);
        FoodTypeInfo GetFoodTypeById(int foodTypeId);
        bool AddUpdateFoodType(FoodTypeInfo foodTypeRequest);
    }
}
