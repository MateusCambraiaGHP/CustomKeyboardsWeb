using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Customers;
using CustomKeyboardsWeb.Application.Features.QueryHandlers.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Customers;
using Moq;

namespace CustomKeyboardsWeb.Tests.Features.Queries.Customers
{
    public class GetCustomerListQueryTests
    {
        private readonly GetCustomerByIdHandler _handler;
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public GetCustomerListQueryTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetCustomerByIdHandler(_customerRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsCustomerByIdQueryResponse()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var customerViewModel = new CustomerViewModel
            {
                Id = customerId,
                Name = "John Doe",
                FantasyName = "JD Corp",
            };

            var request = new GetCustumerByIdQuery(customerId);
            var cancellationToken = new CancellationToken();

            _customerRepositoryMock.Setup(repo => repo.FindById(customerId))
                                   .ReturnsAsync(Customer.Create(
                                        Name.Create(customerViewModel.Name),
                                        FantasyName.Create(customerViewModel.FantasyName),
                                        Cep.Create(customerViewModel.Cep),
                                        Address.Create(customerViewModel.Address),
                                        FederativeUnit.Create(customerViewModel.FederativeUnit),
                                        Phone.Create(customerViewModel.Phone),
                                        customerViewModel.Active));

            _mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(It.IsAny<Customer>()))
                       .Returns((Customer source) => new CustomerViewModel
                       {
                           Id = source.Id,
                           Name = source.Name.Value,
                           FantasyName = source.FantasyName.Value,
                       });

            // Act
            var response = await _handler.Handle(request, cancellationToken);

            // Assert
            Assert.NotNull(response.Customer);
            Assert.True(response.Success);
        }

        [Fact]
        public async Task Handle_ExceptionThrown_ThrowsException()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var request = new GetCustumerByIdQuery(customerId);
            var cancellationToken = new CancellationToken();

            _customerRepositoryMock.Setup(repo => repo.FindById(customerId)).Throws<Exception>();

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, cancellationToken));
        }
    }
}
