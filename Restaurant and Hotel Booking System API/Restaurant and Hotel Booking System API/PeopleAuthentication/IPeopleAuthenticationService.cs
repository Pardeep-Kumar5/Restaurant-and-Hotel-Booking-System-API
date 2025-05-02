

using Restaurant_and_Hotel_Booking_System_API.PeopleAuthentication.Model;

namespace Restaurant_and_Hotel_Booking_System_API.PeopleAuthentication
{
    public interface IPeopleAuthenticationService
    {
        bool LoginPeople(LoginRequest loginInfo);
        bool RegisterPeople(RegisterRequest registerRequest);
       
    }
}
