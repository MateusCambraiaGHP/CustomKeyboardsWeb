using CustomKeyboardsWeb.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Dto
{
    public class CustomerDto 
    {

        [Required]
        public string? Active { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? FantasyName { get; set; }
        [Required]
        public string? Cep { get; set; }
        [Required]
        public string? Adress { get; set; }
        [Required]
        public string? FederativeUnit { get; set; }
        [Required]
        public string? Phone { get; set; }
        public string CreatedBy { get; set; } = "Administrator";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
