using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Application.Cummon.Abstractions
{
    public interface IJwtProvider
    {
        string Generate(Member member);
    }
}
