using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_and_Hotel_Booking_System_API.Users.Model;
using RestaurantHotelBookingSystem.Web.Authentication;

namespace RestaurantHotelBookingSystem.Web.Controllers
{
    //[Authorize]
    [ServiceFilter(typeof(ActiveUserHandler))]
    public class BaseRestaurantController : ControllerBase
    {
        public CurrentUserInfo CurrentUserInfo { get; set; }

    }
}
