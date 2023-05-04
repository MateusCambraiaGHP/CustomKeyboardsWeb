using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Features.Keyboard.Commands.CreateKeyboard
{
    public class CreateKeyboardDto
    {
        [Required]
        public string? Active { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? IdSwitch { get; set; }
        public int? IdKey { get; set; }
        [Required]
        public double? Price { get; set; }
    }
}
