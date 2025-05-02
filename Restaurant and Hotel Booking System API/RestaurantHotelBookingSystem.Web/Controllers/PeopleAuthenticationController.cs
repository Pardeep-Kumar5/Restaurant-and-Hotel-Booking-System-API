using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant_and_Hotel_Booking_System_API.Common.Exceptions;
using Restaurant_and_Hotel_Booking_System_API.Food.Models;
using Restaurant_and_Hotel_Booking_System_API.PeopleAuthentication;
using Restaurant_and_Hotel_Booking_System_API.PeopleAuthentication.Model;
using SubmittalTransmittal.Web.Response;

namespace RestaurantHotelBookingSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleAuthenticationController(
        IErrorLogger logger,
        IPeopleAuthenticationService authenticationService) : BaseRestaurantController
    {
        [HttpPost("LoginPeople")]
        public IActionResult LoginPeople([FromBody] LoginRequest loginRequest)
        {
            var response = ResponseFactory.CreateResultResponse(logger, Request, () =>
            {
                return authenticationService.LoginPeople(loginRequest);
            });
            return Ok(response);
        }

        [HttpPost("RegisterPeople")]
        public IActionResult RegisterPeople([FromBody] RegisterRequest registerRequest)
        {
            var response = ResponseFactory.CreateResultResponse(logger, Request, () =>
            {
                return authenticationService.RegisterPeople(registerRequest);
            });
            return Ok(response);
        }
    }
}
