using System.ComponentModel.DataAnnotations;

namespace RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables
{
    public class Restaurants
    {
        [Key]
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public string Location  { get; set; }
        public string Image { get; set; }
        public int  FoodTypeId { get; set; }
        public FoodType FoodType { get; set; }
    }
}
