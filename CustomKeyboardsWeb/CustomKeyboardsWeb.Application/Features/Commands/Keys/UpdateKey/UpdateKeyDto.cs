using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keys.UpdateKey
{
    public class UpdateKeyDto
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public string? Active { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double? Price { get; set; }
    }
}
