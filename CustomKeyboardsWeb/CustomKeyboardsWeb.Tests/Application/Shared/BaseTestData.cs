using System.Collections;

namespace CustomKeyboardsWeb.Tests.Application.Shared
{
    public abstract class BaseTestData : IEnumerable<object[]>
    {
        public dynamic CommandDto { get; protected set; }
        public bool ExpectedSucess { get; protected set; }

        public BaseTestData(bool expectedSucess = default, object commandDto = default!)
        {
            CommandDto = commandDto;
            ExpectedSucess = expectedSucess;
        }

        public abstract IEnumerator<object[]> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
