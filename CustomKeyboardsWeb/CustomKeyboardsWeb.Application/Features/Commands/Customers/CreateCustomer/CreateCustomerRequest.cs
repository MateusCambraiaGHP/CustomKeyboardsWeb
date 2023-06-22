namespace CustomKeyboardsWeb.Application.Features.Commands.Customers.CreateCustomer
{
    public class CreateCustomerRequest
    {
        public string? Active { get; set; }
        public string? Name { get; set; }
        public string? FantasyName { get; set; }
        public string? Cep { get; set; }
        public string? Address { get; set; }
        public string? FederativeUnit { get; set; }
        public string? Phone { get; set; }
        public string CreatedBy { get; set; } = "Administrator";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public CreateCustomerRequest(
            string? active,
            string? name,
            string? fantasyName,
            string? cep,
            string? address,
            string? federativeUnit,
            string? phone,
            string createdBy,
            DateTime createdAt,
            string? updatedBy,
            DateTime? updatedAt)
        {
            Active = active;
            Name = name;
            FantasyName = fantasyName;
            Cep = cep;
            Address = address;
            FederativeUnit = federativeUnit;
            Phone = phone;
            CreatedBy = createdBy;
            CreatedAt = createdAt;
            UpdatedBy = updatedBy;
            UpdatedAt = updatedAt;
        }
    }
}
