namespace CustomKeyboardsWeb.Core.Messages
{
    public class BaseHandlerResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }

        public BaseHandlerResponse()
        {
            Success = true;
        }

        public BaseHandlerResponse(string message = "")
        {
            Success = true;
            Message = message;
        }

        public BaseHandlerResponse(bool success, string message = "")
        {
            Success = success;
            Message = message;
            ValidationErrors = new List<string>();
        }
    }
}
