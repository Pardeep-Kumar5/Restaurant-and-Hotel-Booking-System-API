using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_and_Hotel_Booking_System_API.Common.Exceptions;
using Restaurant_and_Hotel_Booking_System_API.Food.Models;
using Restaurant_and_Hotel_Booking_System_API.Food.Services;
using SubmittalTransmittal.Web.Response;

namespace RestaurantHotelBookingSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTypesController(
        IErrorLogger logger,
        IFoodTypeService foodTypeService) : BaseRestaurantController
    {
        [HttpGet("GetAllFoodTypes")]
        public IActionResult GetAllFoodTypes()
        {
            var response = ResponseFactory.CreateResultsResponse(logger, Request, () =>
            {
                 return foodTypeService.GetAllFoodTypes();
            });
            return Ok(response);
        }

        [HttpGet("GetFoodTypeByName")]
        public IActionResult GetFoodTypeByName(string foodTypeName)
        {
            var response = ResponseFactory.CreateResultResponse(logger, Request, () =>
            {
                return foodTypeService.GetFoodTypeByName(foodTypeName);
            });
            return Ok(response);
        }

        [HttpPost("AddUpdateFoodType")]
        public IActionResult AddUpdateFoodType([FromBody] FoodTypeInfo foodTypeInfo)
        {
            var response = ResponseFactory.CreateResultResponse(logger, Request, () =>
            {
                return foodTypeService.AddUpdateFoodType(foodTypeInfo);
            });
            return Ok(response);
        }
    }
}
