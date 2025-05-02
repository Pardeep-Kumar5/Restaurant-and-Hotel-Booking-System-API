using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant_and_Hotel_Booking_System_API.Common.Exceptions;
using Restaurant_and_Hotel_Booking_System_API.Food.Models;
using Restaurant_and_Hotel_Booking_System_API.Food.Services;
using Restaurant_and_Hotel_Booking_System_API.Peoples.Services;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;
using SubmittalTransmittal.Web.Response;

namespace RestaurantHotelBookingSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController(
        IErrorLogger logger,
        IFoodsServices foodsServices) : BaseRestaurantController
    {
        [HttpGet("GetAllFoodsList")]
        public IActionResult GetAllFoodsList()
        {
            var response = ResponseFactory.CreateResultsResponse(logger, Request, () =>
            {
                return foodsServices.GetAllFoodsList();
            });
            return Ok(response);
        }

        [HttpGet("GetAllFoodListByFoodTypeId")]
        public IActionResult GetAllFoodListByFoodTypeId(int foodTypeId)
        {
            var response = ResponseFactory.CreateResultsResponse(logger, Request, () =>
            {
                return foodsServices.GetAllFoodListByFoodTypeId(foodTypeId);
            });
            return Ok(response);
        }

        [HttpGet("GetAllFoodsListByRestaurantId")]
        public IActionResult GetAllFoodsListByRestaurantId(int restaurantId)
        {
            var response = ResponseFactory.CreateResultsResponse(logger, Request, () =>
            {
                return foodsServices.GetAllFoodsListByRestaurantId(restaurantId);
            });
            return Ok(response);
        }

        [HttpPost("AddUpdateFood")]
        public IActionResult AddUpdateFood([FromBody] AddUpdaterestaurantsRequest restaurantsRequest)
        {
            var response = ResponseFactory.CreateResultResponse(logger, Request, () =>
            {
                return foodsServices.AddUpdateFood(restaurantsRequest);
            });
            return Ok(response);
        }
    }
}