using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keys.GetKeyList
{
    public record GetKeyListQuery() : IRequest<List<KeyDto>>;
}
