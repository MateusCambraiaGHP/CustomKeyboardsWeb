using CustomKeyboardsWeb.Application.Features.ViewModel.Commom;

namespace CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers
{
    public class SupplierViewModel : BaseViewModel
    {
        public string? Name { get; set; }
        public string? FantasyName { get; set; }
        public string? Cep { get; set; }
        public string? Adress { get; set; }
        public string? FederativeUnit { get; set; }
        public string? Phone { get; set; }
    }
}
