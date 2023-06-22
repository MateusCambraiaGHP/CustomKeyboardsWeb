using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Application.Dto
{
    public class KeyboardDto
    {
        public string? Active { get; set; }
        public string? Name { get; set; }
        public int? IdSwitch { get; set; }
        public int? IdKey { get; set; }
        public double? Price { get; set; }
        public Switch Switch { get; set; }
        public Key Key { get; set; }
    }
}
