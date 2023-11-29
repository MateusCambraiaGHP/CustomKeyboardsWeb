using CustomKeyboardsWeb.Application.Features.CommandHandlers.Commom;
using System.Text.Json.Serialization;

namespace CustomKeyboardsWeb.Application.Features.ViewModel.Customers
{
    public class CustomerViewModel : BaseViewModel
    {
        public string? Name { get; set; }
        public string? FantasyName { get; set; }
        public string? Cep { get; set; }
        public string? Address { get; set; }
        public string? FederativeUnit { get; set; }
        public string? Phone { get; set; }

        [JsonConstructor]
        public CustomerViewModel(
            Guid? id,
            string? active,
            string? name,
            string? fantasyName,
            string? cep,
            string? address,
            string? federativeUnit,
            string? phone,
            string createdBy,
            string? updatedBy,
            DateTime insertionDate,
            DateTime lastModification)
        {
            Id = id;
            Active = active;
            Name = name;
            FantasyName = fantasyName;
            Cep = cep;
            Address = address;
            FederativeUnit = federativeUnit;
            Phone = phone;
            CreatedBy = createdBy;
            UpdatedBy = updatedBy;
            InsertionDate = insertionDate;
            LastModification = lastModification;
        }

        public CustomerViewModel() { }
    }
}
