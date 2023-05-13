using System.ComponentModel.DataAnnotations;

namespace CustomKeyboardsWeb.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerDto
    {
        public string Active { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string FantasyName { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string FederativeUnit { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
