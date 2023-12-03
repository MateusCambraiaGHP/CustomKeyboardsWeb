namespace CustomKeyboardsWeb.Application.Dtos.Keyboards
{
    public class UpdateKeyboardDto
    {
        public Guid Id { get; set; }
        public string? Active { get; set; }
        public string? Name { get; set; }
        public Guid? IdSwitch { get; set; }
        public Guid? IdKey { get; set; }
        public double Price { get; set; }
    }
}
