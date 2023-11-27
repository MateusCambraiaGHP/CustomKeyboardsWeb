using AutoMapper;
using CustomKeyboardsWeb.Application.Dtos.Customers;
using CustomKeyboardsWeb.Application.Features.CommandHandlers.Customers;
using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Tests.Application.Shared;
using CustomKeyboardsWeb.Tests.Application.Shared.Mocks;
using CustomKeyboardsWeb.Tests.Data.Repositories;
using Moq;

namespace CustomKeyboardsWeb.Tests.Application.Features.Customers.Commands
{
    public class CreateCustomerCommandTests
    {
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CreateCustomerCommandTests()
        {
            _customerRepository = MockCustomerRepository.GetMock();
            _mapper = MockMapper.GetMock();
            _unitOfWork = MockUnitOfWork.GetMock();
        }

        [Fact]
        public async Task ShouldCreate_Customer_ValidData_ReturnSucess()
        {
            //Arrange
            var commandDto = new CustomerDto
            {
                Name = "TesteCreate",
                FantasyName = "TesteCreate",
                Cep = "TesteCreate",
                Address = "TesteCreate",
                FederativeUnit = "MG",
                Phone = "31997876723",
                Active = "1"
            };
            var handler = new CreateCustomerHandler(
                _customerRepository.Object,
                _mapper.Object,
                _unitOfWork.Object);

            //Act
            var response = await handler.Handle(new CreateCustomerCommand(commandDto), CancellationToken.None);

            //Assert
            Assert.True(response.Success == true);
            Assert.True(response.ValidationErrors == null);
            Assert.True(response.Customer != null);
        }
    }
}
