using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Restaurant_and_Hotel_Booking_System_API.Peoples.Model;
using Restaurant_and_Hotel_Booking_System_API.Peoples.Services;
using Restaurant_and_Hotel_Booking_System_API.Users.Model;
using Restaurant_and_Hotel_Booking_System_API.Users.Services;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem;
using RestaurantHotelBookingSystem.Web.Controllers;

namespace RestaurantHotelBookingSystem.Web.Authentication
{
    public class ActiveUserHandler(
        IPeopleService peopleService,
        IRestaurantSystemContext restaurantSystem,
        ICurrentUserInfoService currentUserInfoService) : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = (BaseRestaurantController)context.Controller;

            if (controller is not null)
            {
                controller.CurrentUserInfo = CurrentUserInfo.FromClaim(context.HttpContext.User.Claims);

                var person = "";// peopleService.GetPersonByLoginNameOrEmail(controller.CurrentUserInfo.EmailAddress);

                if (person is null)
                {
                    context.Result = new JsonResult(new
                    {
                        success = false,
                        error = $"Authorization Error: User has a valid CT.gov account and token, but their email address {controller.CurrentUserInfo.EmailAddress} cannot be found in the Compass ProjectManagement Person database table."
                    });
                    return;
                }

                //var personStat = restaurantSystem.PersonStats.FirstOrDefault(x => x.PersonId == person.PersonId);

                //if (personStat is null || personStat.LastActiveDate is null || personStat.LastActiveDate < DateTime.UtcNow.AddDays(-1))
                //{
                //    // update login date for current user if it is not today
                //    personStat = peopleService.UpdatePersonStats(personStat, person.PersonId);
                //}

               // controller.CurrentUserInfo.Person = new PeopleInformation(person, 0);
            //    controller.CurrentUserInfo.PersonId = person.PersonId;

                // pass our current user to our service layer
                currentUserInfoService.Set(controller.CurrentUserInfo);

                // We need to detach this entity from our entity framework so that it does not automatically bind itself to any of our api calls.
                // If this happens, then some api calls that return database model objects that reference the current user may bind themselves to the person object,
                // thereby creating an infinite loop of references and causing the json modeler to fail when returning the response, causing 500 errors.
              //  restaurantSystem.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                //restaurantSystem.Entry(personStat).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }

            await next(); // the actual action being performed by the controller method.
            return;
        }
    }
}
