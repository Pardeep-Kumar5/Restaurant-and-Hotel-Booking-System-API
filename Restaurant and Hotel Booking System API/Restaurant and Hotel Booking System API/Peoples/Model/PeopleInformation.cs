using RestaurantHotelBookingSystem.Infrastructure.RestaurantSystem.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_and_Hotel_Booking_System_API.Peoples.Model
{
    public class PeopleInformation
    {
        public PeopleInformation() {}


        public PeopleInformation(People p, int info)
        {
            // This is legacy logic, remove strings if possible and return actual values
            PersonId = p is null ? 0 : p.PersonId;
            FullName = p?.FullName ?? "No LoginName";
            LastName = p?.LastName ?? "No LoginName";
            Email = p?.Email ?? "No Email";
            Phone = p?.PhoneNumber ?? "No Phone";
            Information = info;
            Order = 0;
        }

     

        public int PersonId { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? LastName { get; set; }
        public string? LoginName { get; set; }
        public string? Title { get; set; }
        public string? Phone { get; set; }
        public int Information { get; set; }
        public int Order { get; set; }
        public SimpleEmployeeUser EmployeeInfo { get; set; }
    }
}
