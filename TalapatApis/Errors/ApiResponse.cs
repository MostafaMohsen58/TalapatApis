namespace TalapatApis.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public String? Message { get; set; }
        public ApiResponse(int statuscode, string? message=null)
        {
                StatusCode = statuscode;
            Message = message?? GetDefaultMessageForStatusCode(StatusCode);
        }

        private string? GetDefaultMessageForStatusCode(int? statusCode)
        {
            // 500 internal server error
            // 400 bad request
            // 401 unauthorized
            // 404 notfound

            return statusCode switch
            {
                400 => "Bad Request",
                401 => " You are unauthorized",
                404 => "Not Found",
                500 => "Internal server error",

                _ => null
            };





        }
    }
}
