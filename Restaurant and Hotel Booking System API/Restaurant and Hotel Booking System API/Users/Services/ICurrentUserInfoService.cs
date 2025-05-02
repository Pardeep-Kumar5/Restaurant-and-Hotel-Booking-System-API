using Restaurant_and_Hotel_Booking_System_API.Users.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_and_Hotel_Booking_System_API.Users.Services
{
    public interface ICurrentUserInfoService
    {
        CurrentUserInfo GetUserInfo();
        int GetUserId();
        void Set(CurrentUserInfo currentUserInfo);

    }
}
