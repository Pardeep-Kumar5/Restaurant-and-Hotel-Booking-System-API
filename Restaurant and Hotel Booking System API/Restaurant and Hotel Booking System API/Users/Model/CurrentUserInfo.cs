
using System.Security.Claims;
using Microsoft.Identity.Web;
using Restaurant_and_Hotel_Booking_System_API.Peoples.Model;

namespace Restaurant_and_Hotel_Booking_System_API.Users.Model
{
    public class CurrentUserInfo
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public PeopleInformation Person { get; set; }


        public static CurrentUserInfo FromClaim(IEnumerable<Claim> claims)
        {
            var currentUserInfo = new CurrentUserInfo();

            foreach (var claim in claims)
            {
                switch (claim.Type)
                {
                    case ClaimConstants.Name:
                        currentUserInfo.Name = claim.Value;
                        break;
                    case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn":
                    case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress":
                        currentUserInfo.EmailAddress = claim.Value;
                        break;
                }
            }

            return currentUserInfo;
        }
    }
}
