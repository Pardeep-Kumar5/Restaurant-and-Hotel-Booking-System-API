using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_and_Hotel_Booking_System_API.Common.Exceptions;
using Restaurant_and_Hotel_Booking_System_API.Peoples.Model;
using Restaurant_and_Hotel_Booking_System_API.Peoples.Services;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem;
using RestaurantHotelBookingSystem.Web.Response;
using SubmittalTransmittal.Web.Response;

namespace RestaurantHotelBookingSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController(IErrorLogger logger,
        IRestaurantSystemContext restaurantSystem,
        IPeopleService peopleService) : BaseRestaurantController
    {
        [HttpGet("GetPersonById")]
        public IActionResult GetPersonById([FromQuery] int id)
        {
            var response = ResponseFactory.CreateResultResponse(logger, Request, () =>
            {
                return peopleService.GetPersonById(id);
            });
            return Ok(response);
        }
    }
}
