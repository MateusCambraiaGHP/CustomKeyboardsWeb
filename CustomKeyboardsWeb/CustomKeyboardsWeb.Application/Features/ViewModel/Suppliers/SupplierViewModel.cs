namespace CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers
{
    public class SupplierViewModel
    {
        public Guid? Id { get; set; }
        public string? Active { get; set; }
        public string? Name { get; set; }
        public string? FantasyName { get; set; }
        public string? Cep { get; set; }
        public string? Adress { get; set; }
        public string? FederativeUnit { get; set; }
        public string? Phone { get; set; }
        public DateTime InsertionDate { get; protected set; }
        public DateTime LastModification { get; protected set; }
    }
}
