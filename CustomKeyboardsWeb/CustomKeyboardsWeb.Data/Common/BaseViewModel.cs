namespace CustomKeyboardsWeb.Application.Features.ViewModel.Commom
{
    public abstract class BaseViewModel
    {
        public Guid? Id { get; set; }
        public string? Active { get; set; }
        public string CreatedBy { get; set; } = "Administrator";
        public string? UpdatedBy { get; set; }
        public DateTime InsertionDate { get; set; }
        public DateTime LastModification { get; set; }
    }
}
