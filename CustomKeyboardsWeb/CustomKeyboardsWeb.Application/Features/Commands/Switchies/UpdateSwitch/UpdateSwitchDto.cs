using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Features.Commands.Switchies.UpdateSwitch
{
    public class UpdateSwitchDto
    {
        [Required]
        public int? Id { get; set; }
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
