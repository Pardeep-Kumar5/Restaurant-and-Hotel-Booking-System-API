using Restaurant_and_Hotel_Booking_System_API.Common.Exceptions;
using RestaurantHotelBookingSystem.Web.Response;

namespace SubmittalTransmittal.Web.Response
{
    public static class ResponseFactory
    {
        public static ResponseItems<TResult> CreateResultsResponse<TResult>(IErrorLogger logger, HttpRequest request, Func<List<TResult>> operation)
        {
            try
            {
                return new ResponseItems<TResult>
                {
                    Results = operation(),
                };
            }
            catch (Exception ex)
            {
                return HandleResultsError<TResult>(logger, request, ex);
            }
        }

        public static ResponseItem<TResult> CreateResultResponse<TResult>(IErrorLogger logger, HttpRequest request, Func<TResult> operation)
        {
            try
            {
                return new ResponseItem<TResult>
                {
                    Result = operation(),
                };
            }
            catch (Exception ex)
            {
                return HandleResultError<TResult>(logger, request, ex);
            }
        }

        public static async Task<ResponseItem<TResult>> CreateAsyncResultResponse<TResult>(IErrorLogger logger, HttpRequest request, Func<Task<TResult>> operation)
        {
            try
            {
                return new ResponseItem<TResult>
                {
                    Result = await operation(),
                };
            }
            catch (Exception ex)
            {
                return HandleResultError<TResult>(logger, request, ex);
            }
        }

        public static async Task<ResponseItems<TResult>> CreateAsyncResultsResponse<TResult>(IErrorLogger logger, HttpRequest request, Func<Task<List<TResult>>> operation)
        {
            try
            {
                return new ResponseItems<TResult>
                {
                    Results = await operation(),
                };
            }
            catch (Exception ex)
            {
                return HandleResultsError<TResult>(logger, request, ex);
            }
        }

        private static ResponseItems<TResult> HandleResultsError<TResult>(IErrorLogger logger, HttpRequest request, Exception ex)
        {
            logger.LogException(ex, request.Path, request.Host.Value, ex.Message);

            return new ResponseItems<TResult>
            {
                Error = true,
                ErrorMessage = ex.GetType() == typeof(SafeApplicationArgumentException) ? ex.Message : ex.ToString(),
            };
        }

        private static ResponseItem<TResult> HandleResultError<TResult>(IErrorLogger logger, HttpRequest request, Exception ex)
        {
            logger.LogException(ex, request.Path, request.Host.Value, ex.Message);

            return new ResponseItem<TResult>
            {
                Error = true,
                ErrorMessage = ex.GetType() == typeof(SafeApplicationArgumentException) ? ex.Message : ex.ToString(),
            };
        }
    }
}
