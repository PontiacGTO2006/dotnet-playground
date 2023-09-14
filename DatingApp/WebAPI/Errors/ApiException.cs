namespace WebAPI.Errors
{
    public class ApiException
    {
        private string v;

        public ApiException(int statusCode, string message, string v)
        {
            StatusCode = statusCode;
            Message = message;
            this.v = v;
        }


        public ApiException(int statusCode, string message, string details, string v) 
        {
            this.StatusCode = statusCode;
                this.Message = message;
                this.Details = details;
               
        }
                public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}