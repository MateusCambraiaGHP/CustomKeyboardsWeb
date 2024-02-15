namespace CustomKeyboardsWeb.Data.Common.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string recipientEmail, string message);
    }
}
