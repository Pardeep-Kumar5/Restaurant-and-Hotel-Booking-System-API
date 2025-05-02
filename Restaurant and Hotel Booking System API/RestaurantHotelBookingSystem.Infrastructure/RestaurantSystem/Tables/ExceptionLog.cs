using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables
{
    public class ExceptionLog
    {
        [Key]
        public int Id { get; set; }
        public int ExceptionLogId { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public string ExceptionType { get; set; } = null!;

        public string ExceptionMessage { get; set; } = null!;

        public string CallStackTrace { get; set; } = null!;

        public string? ApiUrl { get; set; } = null;

        public string? ClientUrl { get; set; } = null;
    }
}
