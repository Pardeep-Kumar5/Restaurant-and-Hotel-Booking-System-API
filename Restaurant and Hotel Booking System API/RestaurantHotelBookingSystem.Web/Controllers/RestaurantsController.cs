using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant_and_Hotel_Booking_System_API.Common.Exceptions;
using Restaurant_and_Hotel_Booking_System_API.Food.Models;
using Restaurant_and_Hotel_Booking_System_API.Restaurant.Model;
using Restaurant_and_Hotel_Booking_System_API.Restaurant.Services;
using SubmittalTransmittal.Web.Response;

namespace RestaurantHotelBookingSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController(
        IErrorLogger logger,
        IRestaurantService restaurantService) : BaseRestaurantController
    {
        [HttpGet("GetAllRestaurants")]
        public IActionResult GetAllRestaurants()
        {
            var response = ResponseFactory.CreateResultsResponse(logger, Request, () =>
            {
                return restaurantService.GetAllRestaurants();
            });
            return Ok(response);
        }

        [HttpGet("GetRestaurantsByFoodTypeId")]
        public IActionResult GetRestaurantsByFoodTypeId(int foodTypeId)
        {
            var response = ResponseFactory.CreateResultsResponse(logger, Request, () =>
            {
                return restaurantService.GetRestaurantsByFoodTypeId(foodTypeId);
            });
            return Ok(response);
        }

        //[HttpGet("GetAllFoodListByFoodTypeId")]
        //public IActionResult GetAllFoodListByFoodTypeId(int foodCategoryId)
        //{
        //    var response = ResponseFactory.CreateResultsResponse(logger, Request, () =>
        //    {
        //        return foodsServices.GetAllFoodListByFoodTypeId(foodCategoryId);
        //    });
        //    return Ok(response);
        //}

        [HttpPost("AddUpdateRestaurants")]
        public IActionResult AddUpdateRestaurants([FromBody] RestaurantRequest restaurantsRequest)
        {
            var response = ResponseFactory.CreateResultResponse(logger, Request, () =>
            {
                return restaurantService.AddUpdateRestaurants(restaurantsRequest);
            });
            return Ok(response);
        }
    }
}
