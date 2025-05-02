using Restaurant_and_Hotel_Booking_System_API.Common.Exceptions;
using Restaurant_and_Hotel_Booking_System_API.Peoples.Model;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;


namespace Restaurant_and_Hotel_Booking_System_API.Peoples.Services
{
    public class PeopleService(IRestaurantSystemContext restaurantSystem) : IPeopleService
    {

        public People GetPersonByLoginNameOrEmail(string name)
        {
            var contractName = GetPersonContractName(name);
            return restaurantSystem.People
                        .Where(x =>
                            x.FullName == name ||
                            x.LastName == contractName
                            || x.Email == name
                            || x.Email == contractName
                        ).FirstOrDefault();
        }

        public PeopleInformation GetPersonById(int id)
        {
            throw new NotImplementedException();
        }

        internal static string GetPersonContractName(string email)
        {
            if (email != null)
            {
                if (email.Contains("@gmail.com", StringComparison.CurrentCultureIgnoreCase))
                {

                    return email;
                }
                else if (email.Contains("@outlook.com", StringComparison.CurrentCultureIgnoreCase))
                {

                    return email;
                }
                else if (email.Contains("@microsoft.com", StringComparison.CurrentCultureIgnoreCase))
                {

                    return email.ToLower();
                }
            }

            return email;
        }
    }
}
