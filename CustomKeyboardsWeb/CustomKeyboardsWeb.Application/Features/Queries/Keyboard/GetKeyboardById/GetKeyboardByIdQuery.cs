using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Keyboard.Query.GetKeyboardById
{
    public record GetKeyboardByIdQuery(int Id) : IRequest<KeyboardDto>;
}
