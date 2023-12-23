using AutoMapper;
using CustomKeyboardsWeb.Application.Dtos.Customers;
using CustomKeyboardsWeb.Application.Features.CommandHandlers.Customers;
using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
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
        private readonly Mock<ICacheService> _cacheService;

        public CreateCustomerCommandTests()
        {
            _customerRepository = MockCustomerRepository.GetMock();
            _mapper = MockMapper.GetMock();
            _unitOfWork = MockUnitOfWork.GetMock();
            _cacheService = MockCacheService.GetMock();
        }

        [Fact]
        public async Task ShouldCreate_Customer_ValidData_ReturnSucess()
        {
            //Arrange
            var commandDto = new CreateCustomerDto
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
                _unitOfWork.Object,
                _cacheService.Object);

            //Act
            var response = await handler.Handle(new CreateCustomerCommand(commandDto), CancellationToken.None);

            //Assert
            Assert.True(response.Success == true);
            Assert.True(response.ValidationErrors == null);
            Assert.True(response.Customer != null);
        }

        [Fact]
        public async Task ShouldCreate_Customer_WithoutName_ReturnError()
        {
            //Arrange
            var commandDto = new CreateCustomerDto
            {
                Name = "",
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
                _unitOfWork.Object,
                _cacheService.Object);

            //Act
            var response = await handler.Handle(new CreateCustomerCommand(commandDto), CancellationToken.None);

            //Assert
            Assert.True(response.Success == false);
            Assert.True(response.ValidationErrors != null);
            Assert.True(response.Customer == null);
        }

        [Fact]
        public async Task ShouldCreate_Customer_WithoutFantasyName_ReturnError()
        {
            //Arrange
            var commandDto = new CreateCustomerDto
            {
                Name = "TesteCreate",
                FantasyName = "",
                Cep = "TesteCreate",
                Address = "TesteCreate",
                FederativeUnit = "MG",
                Phone = "31997876723",
                Active = "1"
            };
            var handler = new CreateCustomerHandler(
                _customerRepository.Object,
                _mapper.Object,
                _unitOfWork.Object,
                _cacheService.Object);

            //Act
            var response = await handler.Handle(new CreateCustomerCommand(commandDto), CancellationToken.None);

            //Assert
            Assert.True(response.Success == false);
            Assert.True(response.ValidationErrors != null);
            Assert.True(response.Customer == null);
        }

        [Fact]
        public async Task ShouldCreate_Customer_WithoutCep_ReturnError()
        {
            //Arrange
            var commandDto = new CreateCustomerDto
            {
                Name = "TesteCreate",
                FantasyName = "TesteCreate",
                Cep = "",
                Address = "TesteCreate",
                FederativeUnit = "MG",
                Phone = "31997876723",
                Active = "1"
            };
            var handler = new CreateCustomerHandler(
                _customerRepository.Object,
                _mapper.Object,
                _unitOfWork.Object,
                _cacheService.Object);

            //Act
            var response = await handler.Handle(new CreateCustomerCommand(commandDto), CancellationToken.None);

            //Assert
            Assert.True(response.Success == false);
            Assert.True(response.ValidationErrors != null);
            Assert.True(response.Customer == null);
        }

        [Fact]
        public async Task ShouldCreate_Customer_WithoutAddress_ReturnError()
        {
            //Arrange
            var commandDto = new CreateCustomerDto
            {
                Name = "TesteCreate",
                FantasyName = "TesteCreate",
                Cep = "TesteCreate",
                Address = "",
                FederativeUnit = "MG",
                Phone = "31997876723",
                Active = "1"
            };
            var handler = new CreateCustomerHandler(
                _customerRepository.Object,
                _mapper.Object,
                _unitOfWork.Object,
                _cacheService.Object);

            //Act
            var response = await handler.Handle(new CreateCustomerCommand(commandDto), CancellationToken.None);

            //Assert
            Assert.True(response.Success == false);
            Assert.True(response.ValidationErrors != null);
            Assert.True(response.Customer == null);
        }

        [Fact]
        public async Task ShouldCreate_Customer_WithoutFederativeUnit_ReturnError()
        {
            //Arrange
            var commandDto = new CreateCustomerDto
            {
                Name = "TesteCreate",
                FantasyName = "TesteCreate",
                Cep = "TesteCreate",
                Address = "TesteCreate",
                FederativeUnit = "",
                Phone = "31997876723",
                Active = "1"
            };
            var handler = new CreateCustomerHandler(
                _customerRepository.Object,
                _mapper.Object,
                _unitOfWork.Object,
                _cacheService.Object);

            //Act
            var response = await handler.Handle(new CreateCustomerCommand(commandDto), CancellationToken.None);

            //Assert
            Assert.True(response.Success == false);
            Assert.True(response.ValidationErrors != null);
            Assert.True(response.Customer == null);
        }

        [Fact]
        public async Task ShouldCreate_Customer_WithoutActive_ReturnError()
        {
            //Arrange
            var commandDto = new CreateCustomerDto
            {
                Name = "TesteCreate",
                FantasyName = "TesteCreate",
                Cep = "TesteCreate",
                Address = "TesteCreate",
                FederativeUnit = "MG",
                Phone = "31997876723",
                Active = ""
            };
            var handler = new CreateCustomerHandler(
                _customerRepository.Object,
                _mapper.Object,
                _unitOfWork.Object,
                _cacheService.Object);

            //Act
            var response = await handler.Handle(new CreateCustomerCommand(commandDto), CancellationToken.None);

            //Assert
            Assert.True(response.Success == false);
            Assert.True(response.ValidationErrors != null);
            Assert.True(response.Customer == null);
        }

        [Fact]
        public async Task ShouldCreate_Customer_WithoutPhone_ReturnError()
        {
            //Arrange
            var commandDto = new CreateCustomerDto
            {
                Name = "TesteCreate",
                FantasyName = "TesteCreate",
                Cep = "TesteCreate",
                Address = "TesteCreate",
                FederativeUnit = "MG",
                Phone = "",
                Active = "1"
            };
            var handler = new CreateCustomerHandler(
                _customerRepository.Object,
                _mapper.Object,
                _unitOfWork.Object,
                _cacheService.Object);

            //Act
            var response = await handler.Handle(new CreateCustomerCommand(commandDto), CancellationToken.None);

            //Assert
            Assert.True(response.Success == false);
            Assert.True(response.ValidationErrors != null);
            Assert.True(response.Customer == null);
        }
    }
}
