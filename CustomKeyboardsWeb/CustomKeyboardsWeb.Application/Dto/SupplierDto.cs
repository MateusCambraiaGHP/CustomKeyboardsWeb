using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Dto
{
    public class SupplierDto
    {
        public string? Active { get; set; }
        public string? Name { get; set; }
        public string? FantasyName { get; set; }
        public string? Cep { get; set; }
        public string? Adress { get; set; }
        public string? FederativeUnit { get; set; }
        public string? Phone { get; set; }
    }
}
