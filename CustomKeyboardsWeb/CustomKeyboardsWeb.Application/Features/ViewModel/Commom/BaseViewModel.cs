namespace CustomKeyboardsWeb.Application.Features.ViewModel.Commom
{
    public abstract class BaseViewModel
    {
        public Guid Id { get; set; }
        public string Active { get; set; } = null!;
        public string InsertionBy { get; set; } = null!;
        public string? ModificationBy { get; set; }
        public DateTime InsertionDate { get; set; }
        public DateTime LastModification { get; set; }
    }
}
