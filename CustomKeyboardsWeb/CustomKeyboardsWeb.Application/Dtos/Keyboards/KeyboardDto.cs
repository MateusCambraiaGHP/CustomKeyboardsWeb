namespace CustomKeyboardsWeb.Application.Dtos.Keyboards
{
    public class KeyboardDto
    {
        public string? Active { get; set; }
        public string? Name { get; set; }
        public Guid? IdSwitch { get; set; }
        public Guid? IdKey { get; set; }
        public double Price { get; set; }
    }
}
