using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_and_Hotel_Booking_System_API.Common.Exceptions
{
    public interface IErrorLogger
    {
        void LogError(string errorType, string error);
        void LogException(Exception exception, string apiUrl, string clientUrl, string message);
    }
}
