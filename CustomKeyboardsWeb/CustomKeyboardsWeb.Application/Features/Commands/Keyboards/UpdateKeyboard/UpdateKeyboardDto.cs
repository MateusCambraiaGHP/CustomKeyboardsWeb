using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keyboards.UpdateKeyboard
{
    public class UpdateKeyboardDto
    {
        [Required]
        public int? Id { get; set; }
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
