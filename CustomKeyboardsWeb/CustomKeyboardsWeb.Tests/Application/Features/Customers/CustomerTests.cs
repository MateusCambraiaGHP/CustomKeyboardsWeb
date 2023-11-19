using AutoMapper;
using CustomKeyboardsWeb.Application.Features.CommandHandlers.Customers;
using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Tests.Application.Shared;
using CustomKeyboardsWeb.Tests.Application.Shared.Mocks;
using CustomKeyboardsWeb.Tests.Data.Repositories;
using Moq;

namespace CustomKeyboardsWeb.Tests.Application.Features.Customers
{
    public class CustomerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepository = MockCustomerRepository.GetMock();
        private readonly Mock<IMapper> _mapper = MockMapper.GetMock();
        private readonly Mock<IUnitOfWork> _unitOfWork = MockUnitOfWork.GetMock();

        public CustomerTests() { }

        [Theory]
        [ClassData(typeof(CreateCustomerTestData))]
        public async Task ShouldCreate_Customer(BaseTestData testData)
        {
            var handler = new CreateCustomerHandler(_customerRepository.Object, _mapper.Object, _unitOfWork.Object);

            var created = await handler.Handle(new CreateCustomerCommand(testData.CommandDto), CancellationToken.None);

            Assert.True(created.Success == testData.ExpectedSucess);
        }
    }
}
