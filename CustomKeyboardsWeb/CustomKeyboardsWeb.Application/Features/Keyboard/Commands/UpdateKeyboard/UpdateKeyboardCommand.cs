using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Keyboard.Commands.UpdateKeyboard
{
    public record UpdateKeyboardCommand(KeyboardDto KeyboardDto) : IRequest<KeyboardDto>;
}
