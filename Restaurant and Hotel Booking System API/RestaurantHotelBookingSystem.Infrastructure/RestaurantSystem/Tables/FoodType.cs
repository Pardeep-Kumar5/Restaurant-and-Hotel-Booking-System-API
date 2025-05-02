using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables
{
    public class FoodType
    {
        [Key]
        public int FoodTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
