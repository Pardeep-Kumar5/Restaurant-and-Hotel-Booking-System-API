namespace RestaurantHotelBookingSystem.Web.Response
{
    public class ResponseItem<T> : ResponseBase
    {
        public T Result { get; set; }
    }
}
