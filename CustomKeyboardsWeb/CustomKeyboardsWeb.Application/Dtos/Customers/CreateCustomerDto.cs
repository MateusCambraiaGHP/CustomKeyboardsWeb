namespace CustomKeyboardsWeb.Application.Dtos.Customers
{
    public class CreateCustomerDto
    {
        public string? Active { get; set; }
        public string? Name { get; set; }
        public string? FantasyName { get; set; }
        public string? Cep { get; set; }
        public string? Address { get; set; }
        public string? FederativeUnit { get; set; }
        public string? Phone { get; set; }
    }
}
