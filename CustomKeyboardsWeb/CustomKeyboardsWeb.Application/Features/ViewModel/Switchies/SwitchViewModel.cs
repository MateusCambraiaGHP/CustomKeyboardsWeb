namespace CustomKeyboardsWeb.Application.Features.ViewModel.Switchies
{
    public class SwitchDto
    {
        public Guid? Id { get; set; }
        public string? Active { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public double Price { get; set; }
        public DateTime InsertionDate { get; protected set; }
        public DateTime LastModification { get; protected set; }
    }
}
