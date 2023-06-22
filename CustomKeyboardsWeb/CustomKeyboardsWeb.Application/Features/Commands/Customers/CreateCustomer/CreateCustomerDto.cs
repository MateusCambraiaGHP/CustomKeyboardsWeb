namespace CustomKeyboardsWeb.Application.Features.Commands.Customers.CreateCustomer
{
    public class CreateCustomerDto
    {
        public CreateCustomerDto(
            string active,
            string name,
            string fantasyName,
            string cep,
            string adress,
            string federativeUnit,
            string phone)
        {
            Active = active;
            Name = name;
            FantasyName = fantasyName;
            Cep = cep;
            Adress = adress;
            FederativeUnit = federativeUnit;
            Phone = phone;
        }

        public string Active { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string FantasyName { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string FederativeUnit { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
