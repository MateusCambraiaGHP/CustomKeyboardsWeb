namespace CustomKeyboardsWeb.Application.Dtos.Keys
{
    public class UpdateKeyDto
    {
        public Guid Id { get; set; }
        public string? Active { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
    }
}
