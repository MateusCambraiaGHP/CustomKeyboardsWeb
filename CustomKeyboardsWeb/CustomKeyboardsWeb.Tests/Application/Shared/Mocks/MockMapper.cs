using AutoMapper;
using CustomKeyboardsWeb.Application.Dtos.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Customers;
using Moq;

namespace CustomKeyboardsWeb.Tests.Application.Shared.Mocks
{
    public class MockMapper
    {
        public static Mock<IMapper> GetMock()
        {
            var mock = new Mock<IMapper>();
            SetupCustomer(mock);
            SetupCustomerDto(mock);

            return mock;
        }

        private static void SetupCustomer(Mock<IMapper> mock)
        {
            mock.Setup(m => m.Map<Customer>(It.IsAny<CreateCustomerDto>()))
                   .Returns((CreateCustomerDto dto) => Customer.Create(
                       name: Name.Create("TesteCreate"),
                       fantasyName: FantasyName.Create("TesteCreate"),
                       cep: Cep.Create("TesteCreate"),
                       address: Address.Create("TesteCreate"),
                       federativeUnit: FederativeUnit.Create("MG"),
                       phone: Phone.Create("31997876723"),
                       active: "1"));
        }

        private static void SetupCustomerDto(Mock<IMapper> mock)
        {
            mock.Setup(m => m.Map<CustomerViewModel>(It.IsAny<Customer>()))
                   .Returns((Customer customer) => new CustomerViewModel
                   {
                       Id = customer.Id,
                       InsertionDate = customer.InsertionDate,
                       FantasyName = customer.FantasyName.Value,
                       Active = customer.Active,
                       Address = customer.Address.Value,
                       Cep = customer.Cep.Value,
                       InsertionBy = customer.InsertionBy,
                       FederativeUnit = customer.FederativeUnit.Value,
                       LastModification = customer.LastModification,
                       Name = customer.Name.Value,
                       Phone = customer.Phone.Value,
                       ModificationBy = customer.ModificationBy
                   });
        }
    }
}
