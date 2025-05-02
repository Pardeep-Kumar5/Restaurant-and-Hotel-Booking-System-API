using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables
{
    public class Foods
    {
        [Key]
        public int FoodId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsVeg { get; set; } 
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public int FoodTypeId { get; set; }
        public FoodType FoodType { get; set; }
        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public Restaurants Restaurants { get; set; }
    }
}
