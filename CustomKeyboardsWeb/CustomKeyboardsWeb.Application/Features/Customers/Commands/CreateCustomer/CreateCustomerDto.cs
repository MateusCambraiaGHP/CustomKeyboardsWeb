using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Features.Customers.Commands.CreateCustomer
{
    [Serializable]
    public class CreateCustomerDto
    {
        public int? Id { get; set; }
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
        public Dictionary<string, string[]>? Errors { get; set; }
        [Required]
        public string? Phone { get; set; }
        public string CreatedBy { get; set; } = "Administrator";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
