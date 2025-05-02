using Restaurant_and_Hotel_Booking_System_API.Users.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_and_Hotel_Booking_System_API.Users.Services
{
    public class CurrentUserInfoService : ICurrentUserInfoService
    {
        private CurrentUserInfo _currentUserInfo;

        public int GetUserId()
        {
            return _currentUserInfo.PersonId;
        }

        public CurrentUserInfo GetUserInfo()
        {
            return _currentUserInfo;
        }

        public void Set(CurrentUserInfo currentUserInfo)
        {
            _currentUserInfo = currentUserInfo;
        }
    }
}
