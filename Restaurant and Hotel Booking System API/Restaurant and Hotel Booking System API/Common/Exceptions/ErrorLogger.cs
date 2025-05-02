using Restaurant_and_Hotel_Booking_System_API.Users.Services;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_and_Hotel_Booking_System_API.Common.Exceptions
{
    public class ErrorLogger(IRestaurantSystemContext restaurantSystem, ICurrentUserInfoService currentUserInfoService) : IErrorLogger
    {
        public void LogError(string errorType, string error)
        {
            try
            {
                restaurantSystem.ExceptionLogs.Add(new ExceptionLog
                {
                    CreatedBy = currentUserInfoService.GetUserId(),
                    CreatedOn = DateTime.Now,
                    ExceptionType = errorType,
                    ExceptionMessage = error,
                    CallStackTrace = string.Empty,
                });

                restaurantSystem.SaveChanges();
            }
            catch
            {
             
            }
        }

        public void LogException(Exception exception, string apiUrl, string clientUrl, string message)
        {

            try
            {
                restaurantSystem.ExceptionLogs.Add(new ExceptionLog
                {
                    CreatedBy = currentUserInfoService.GetUserId(),
                    CreatedOn = DateTime.Now,
                    ExceptionType = exception.GetType().ToString(),
                    ExceptionMessage = message,
                    CallStackTrace = exception?.StackTrace ?? string.Empty,
                    ApiUrl = apiUrl,
                    ClientUrl = clientUrl,
                });

                restaurantSystem.SaveChanges();
            }
            catch
            {
            }
        }
    }
}
