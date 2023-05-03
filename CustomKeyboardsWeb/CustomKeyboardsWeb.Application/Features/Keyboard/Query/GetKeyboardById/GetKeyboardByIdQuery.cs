using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Keyboard.Query.GetKeyboardById
{
    public record GetKeyboardByIdCommand(int Id) : IRequest<KeyboardDto>;
}
