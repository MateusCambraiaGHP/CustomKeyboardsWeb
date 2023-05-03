using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Features.Key.Commands.UpdateKey
{
    public class UpdateKeyDto
    {
        [Required]
        public string? Active { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double? Price { get; set; }
    }
}
