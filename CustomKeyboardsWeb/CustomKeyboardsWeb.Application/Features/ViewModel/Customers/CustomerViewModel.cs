namespace CustomKeyboardsWeb.Application.Features.ViewModel.Customers
{
    public class CustomerViewModel
    {
        public Guid? Id { get; set; }
        public string? Active { get; set; }
        public string? Name { get; set; }
        public string? FantasyName { get; set; }
        public string? Cep { get; set; }
        public string? Address { get; set; }
        public string? FederativeUnit { get; set; }
        public string? Phone { get; set; }
        public string CreatedBy { get; set; } = "Administrator";
        public string? UpdatedBy { get; set; }
        public DateTime InsertionDate { get; set; }
        public DateTime LastModification { get; set; }
    }
}
