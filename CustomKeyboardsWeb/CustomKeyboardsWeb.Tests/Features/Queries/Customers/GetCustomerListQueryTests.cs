using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Queries.Customers;
using CustomKeyboardsWeb.Application.Features.QueryHandlers.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
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
            var customerId = 1;
            var customer = new Customer { Id = customerId };
            var customerViewModel = new CustomerViewModel { Id = customerId };
            var request = new GetCustumerByIdQuery(customerId);
            var cancellationToken = new CancellationToken();

            _customerRepositoryMock.Setup(repo => repo.FindById(customerId)).ReturnsAsync(customer);
            _mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customer)).Returns(customerViewModel);

            // Act
            var response = await _handler.Handle(request, cancellationToken);

            // Assert
            Assert.NotNull(response.Customer);
            Assert.True(response.Success);
            Assert.Equal(customerViewModel, response.Customer);
        }

        [Fact]
        public async Task Handle_ExceptionThrown_ThrowsException()
        {
            // Arrange
            var customerId = 1;
            var request = new GetCustumerByIdQuery(customerId);
            var cancellationToken = new CancellationToken();

            _customerRepositoryMock.Setup(repo => repo.FindById(customerId)).Throws<Exception>();

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, cancellationToken));
        }
    }
}
