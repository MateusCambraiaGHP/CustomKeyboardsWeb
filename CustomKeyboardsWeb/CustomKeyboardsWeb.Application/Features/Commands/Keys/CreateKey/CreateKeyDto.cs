namespace CustomKeyboardsWeb.Application.Features.Commands.Keys.CreateKey
{
    public class CreateKeyDto
    {
        public string Active { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Price { get; set; }
    }
}
