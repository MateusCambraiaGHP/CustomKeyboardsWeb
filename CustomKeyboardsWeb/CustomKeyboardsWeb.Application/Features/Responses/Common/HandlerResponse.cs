namespace CustomKeyboardsWeb.Application.Features.Responses.Common
{
    public class HandlerResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }

        public HandlerResponse()
        {
            Success = true;
        }

        public HandlerResponse(string message = "")
        {
            Success = true;
            Message = message;
        }

        public HandlerResponse(bool success, string message = "")
        {
            Success = success;
            Message = message;
            ValidationErrors = new List<string>();
        }
    }
}
