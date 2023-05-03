using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Keyboard.Query.GetKeyboardList
{
    public record GetKeyboardListQuery() : IRequest<List<KeyboardDto>>;
}
