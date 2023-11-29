using AutoMapper;
using CustomKeyboardsWeb.Data.Caching;
using Moq;

namespace CustomKeyboardsWeb.Tests.Application.Shared.Mocks
{
    public class MockCacheService
    {
        public static Mock<ICacheService> GetMock()
        {
            var mock = new Mock<ICacheService>();
            return mock;
        }
    }
}
