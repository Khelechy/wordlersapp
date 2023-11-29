namespace WordlersWeb.Models
{
    public class GeneralResponse<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }

        public GeneralResponse()
        {

        }

        public GeneralResponse(string? message, bool isSuccess, T? data)
        {
            Message = message;
            IsSuccess = isSuccess;
            Data = data;
        }
    }
}
