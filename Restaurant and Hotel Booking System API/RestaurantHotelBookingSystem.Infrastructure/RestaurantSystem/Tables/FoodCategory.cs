using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables
{
    public class FoodCategory
    {
        [Key]
        public int FoodCategoryId { get; set; }
        public string Name { get; set; }
    }
}
