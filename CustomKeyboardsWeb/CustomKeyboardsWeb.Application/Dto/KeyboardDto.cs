using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Dto
{
    public class KeyboardDto
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
