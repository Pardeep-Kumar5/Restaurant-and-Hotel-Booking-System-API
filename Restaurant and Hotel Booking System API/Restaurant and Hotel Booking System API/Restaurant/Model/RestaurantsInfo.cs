using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_and_Hotel_Booking_System_API.Restaurant.Model
{
    public class RestaurantsInfo
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public FoodType FoodType { get; set; }
    }
}
