//using System.Text.Json;

//namespace CustomKeyboardsWeb.Application.Configuration
//{
//    public class Response
//    {
//        public bool Success { get; private set; }
//        public string Message { get; set; }
//        public List<string> Errors { get; private set; }

//        public bool Failure => !Success;
//        public string ErrorMessage => JsonSerializer.Serialize(new { Message, Errors });

//        public Response()
//        {
//            Success = true;
//            Message = string.Empty;
//            Errors = new List<string>();
//        }

//        public void AddError(string error, string message)
//        {
//            Errors.Add(error);
//            Success = false;
//            Message = message;
//        }

//        public void AddErrors(List<string> errors, string message)
//        {
//            Errors.AddRange(errors);
//            Success = false;
//            Message = message;
//        }
//    }

//    public static class ResponseExtensions
//    {
//        public static async Task<Response> WriteValidationsToResponseAsync(this Response response, ValidationResult result)
//        {
//            if (result.Errors.Any())
//                response.AddErrors(result.Errors.Select(errors => errors.ErrorMessage).ToList(), "Invalid request!");
//            return await Task.FromResult(response);
//        }
//    }
//}
