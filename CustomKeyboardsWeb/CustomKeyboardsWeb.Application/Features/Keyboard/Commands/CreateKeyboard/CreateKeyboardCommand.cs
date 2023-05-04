using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Keyboard.Commands.CreateKeyboard
{
    public record CreateKeyboardCommand(CreateKeyboardDto KeyboardDto) : IRequest<KeyboardDto>;
}
