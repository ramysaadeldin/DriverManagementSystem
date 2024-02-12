namespace DriverManagementSystem.Common
{

    public class ApiResponse<T>
    {
        public ApiResponse(T data, bool success = true)
        {
            Data = data;
            Success = success;
        }

        public ApiResponse(string message, bool success = false)
        {
            Message = message;
            Success = success;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
