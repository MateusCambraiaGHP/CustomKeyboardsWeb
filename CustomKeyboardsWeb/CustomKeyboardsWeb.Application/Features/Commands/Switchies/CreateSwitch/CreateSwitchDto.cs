namespace CustomKeyboardsWeb.Application.Features.Commands.Switchies.CreateSwitch
{
    public class CreateSwitchDto
    {
        public string Active { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        public double Price { get; set; }
    }
}
