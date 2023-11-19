using CustomKeyboardsWeb.Core.Data;
using Moq;

namespace CustomKeyboardsWeb.Tests.Application.Shared.Mocks
{
    public class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetMock()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(uow => uow.CommitChangesAsync()).Returns(Task.CompletedTask);

            return mock;
        }
    }
}
