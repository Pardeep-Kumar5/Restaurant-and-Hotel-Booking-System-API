using Restaurant_and_Hotel_Booking_System_API.Common.Exceptions;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem;
using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;
using Restaurant_and_Hotel_Booking_System_API.PeopleAuthentication.Model;
using System.Text;


namespace Restaurant_and_Hotel_Booking_System_API.PeopleAuthentication
{
    public class PeopleAuthenticationService(
        IRestaurantSystemContext restaurantSystem) : IPeopleAuthenticationService
    {
        public bool LoginPeople(LoginRequest peopleInfo)
        {

            if (!string.IsNullOrEmpty(peopleInfo.EmailAddress))
            {
                var person = restaurantSystem.People.FirstOrDefault(x => x.Email == peopleInfo.EmailAddress);
                if (person == null)
                {
                    throw new SafeApplicationArgumentException($"Invalid email {peopleInfo.EmailAddress}.");
                }

                if (person.Password != EncryptPassword(peopleInfo.Password))
                {
                    throw new SafeApplicationArgumentException("Invalid password!");
                }

                return true;
            }
            else if (!string.IsNullOrEmpty(peopleInfo.PhoneNumber))
            {
                var person = restaurantSystem.People.FirstOrDefault(x => x.PhoneNumber == peopleInfo.PhoneNumber);
                if (person == null)
                {
                    throw new SafeApplicationArgumentException($"Invalid phone number {peopleInfo.PhoneNumber}.");
                }

                if (person.Password != EncryptPassword(peopleInfo.Password))
                {
                    throw new SafeApplicationArgumentException("Invalid password!");
                }

                return true;
            }

            throw new SafeApplicationArgumentException("Email or phone number must be provided for login.");
        }

        public bool RegisterPeople(RegisterRequest registerRequest)
        {
            if (registerRequest != null)
            {
                if (!string.IsNullOrEmpty(registerRequest.Email))
                {
                    var existingPerson = restaurantSystem.People.FirstOrDefault(x => x.Email == registerRequest.Email);
                    if (existingPerson != null)
                    {
                        throw new SafeApplicationArgumentException($"Email address {registerRequest.Email} already register. Please use another email address.");
                    }
                }
                if (!string.IsNullOrEmpty(registerRequest.PhoneNumber))
                {
                    var existingPerson = restaurantSystem.People.FirstOrDefault(x => x.PhoneNumber == registerRequest.PhoneNumber);
                    if (existingPerson != null)
                    {
                        throw new SafeApplicationArgumentException($"Phone Number {registerRequest.PhoneNumber} already register. Please use another Phone Number.");
                    }
                }

                var people = new People
                {
                    FirstName = registerRequest.FirstName,
                    LastName = registerRequest.LastName,
                    FullName = registerRequest.FirstName + registerRequest.LastName,
                    Email = registerRequest.Email,
                    PhoneNumber = registerRequest.PhoneNumber,
                    Address = registerRequest.Address,
                    Password = EncryptPassword(registerRequest.Password),
                    IsVerified = true,
                    RolesId = registerRequest.RoleId
                };
                restaurantSystem.People.Add(people);
                restaurantSystem.SaveChanges();
            }
            return true;
        }

        private string EncryptPassword(string password)
        {
            byte[] pwd = Encoding.ASCII.GetBytes(password);
            string encodedData = Convert.ToBase64String(pwd);
            return encodedData;
        }
    }
}
