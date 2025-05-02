namespace RestaurantHotelBookingSystem.Web.Response
{
    public class ResponseItems<T> : ResponseBase
    {
        public List<T> Results { get; set; } = new List<T>();
    }
}
