using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Features.Switch.Commands.CreateSwitch
{
    public class CreateSwitchDto
    {
        [Required]
        public string? Active { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public double? Price { get; set; }
    }
}
