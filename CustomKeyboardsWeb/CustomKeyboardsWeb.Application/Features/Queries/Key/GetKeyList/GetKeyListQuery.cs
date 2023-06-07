using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Key.Query.GetKeyList
{
    public record GetKeyListQuery() : IRequest<List<KeyDto>>;
}
