namespace CustomKeyboardsWeb.Application.Features.Keyboard.Commands.CreateKeyboard
{
    public class CreateKeyboardDto
    {
        public string Active { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int IdSwitch { get; set; }
        public int IdKey { get; set; }
        public double Price { get; set; }
    }
}
