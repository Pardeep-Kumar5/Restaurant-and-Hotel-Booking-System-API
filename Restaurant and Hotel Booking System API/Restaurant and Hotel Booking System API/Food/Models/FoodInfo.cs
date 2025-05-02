

using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;

namespace Restaurant_and_Hotel_Booking_System_API.Food.Models
{
    public class FoodInfo
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public bool IsVeg { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public FoodType FoodType { get; set; }
        public Restaurants Restaurants { get; set; }
    }
}
