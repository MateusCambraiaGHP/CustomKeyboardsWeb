using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Dto
{
    public class KeyDto
    {
        [Required]
        public string? Active { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double? Price { get; set; }
    }
}
