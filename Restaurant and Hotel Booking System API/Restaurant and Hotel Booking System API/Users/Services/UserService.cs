using Restaurant_and_Hotel_Booking_System_API.Users.Model;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_and_Hotel_Booking_System_API.Users.Services
{
    public class UserService(RestaurantSystemContext systemContext) : IUserService
    {
        public void  AddUser(CurrentUserInfo user)
        {
          //  systemContext.User.Add(user);
        }
    }
}
