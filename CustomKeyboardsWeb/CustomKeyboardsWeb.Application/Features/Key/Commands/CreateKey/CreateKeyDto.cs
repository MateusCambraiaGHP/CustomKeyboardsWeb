using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Features.Key.Commands.CreateKey
{
    public  class CreateKeyDto
    {
        [Required]
        public string? Active { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double? Price { get; set; }
    }
}
