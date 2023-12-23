using CustomKeyboardsWeb.Domain.Primitives.Entities.Members;

namespace CustomKeyboardsWeb.Application.Cummon.Abstractions
{
    public interface IJwtProvider
    {
        string GenerateToken(Member member);
    }
}
