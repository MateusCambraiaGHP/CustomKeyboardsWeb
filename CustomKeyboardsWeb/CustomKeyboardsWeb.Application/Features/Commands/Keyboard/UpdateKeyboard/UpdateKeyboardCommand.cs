using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Keyboard.Commands.CreateKeyboard;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Keyboard.Commands.UpdateKeyboard
{
    public record UpdateKeyboardCommand(UpdateKeyboardDto KeyboardDto) : IRequest<KeyboardDto>;
}
