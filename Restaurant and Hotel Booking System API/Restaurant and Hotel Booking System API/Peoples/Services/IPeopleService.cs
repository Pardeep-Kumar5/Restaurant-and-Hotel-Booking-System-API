using System;
using Restaurant_and_Hotel_Booking_System_API.Peoples.Model;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;

namespace Restaurant_and_Hotel_Booking_System_API.Peoples.Services
{
    public interface IPeopleService
    {
        PeopleInformation GetPersonById(int id);
        People GetPersonByLoginNameOrEmail(string name);
    }
}
