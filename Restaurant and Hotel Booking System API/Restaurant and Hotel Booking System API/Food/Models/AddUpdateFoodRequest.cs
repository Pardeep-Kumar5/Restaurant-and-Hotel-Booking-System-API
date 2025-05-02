using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_and_Hotel_Booking_System_API.Food.Models
{
    public class AddUpdaterestaurantsRequest
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public bool isVeg { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public int FoodTypeId { get; set; }
        public int RestaurantId { get; set; }
    }
}
