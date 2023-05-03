using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Keyboard.Commands.CreateKeyboard
{
    public record CreateKeyboardCommand(KeyboardDto KeyboardDto) : IRequest<KeyboardDto>;
}
