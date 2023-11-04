using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards
{
    public class KeyboardViewModel
    {
        public Guid? Id { get; set; }
        public string? Active { get; set; }
        public string? Name { get; set; }
        public Guid? IdSwitch { get; set; }
        public Guid? IdKey { get; set; }
        public double Price { get; set; }
        public Switch? Switch { get; set; }
        public Key? Key { get; set; }
        public DateTime InsertionDate { get; protected set; }
        public DateTime LastModification { get; protected set; }
    }
}
