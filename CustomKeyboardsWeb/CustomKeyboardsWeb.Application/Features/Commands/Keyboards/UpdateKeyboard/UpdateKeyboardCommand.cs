using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keyboards.UpdateKeyboard
{
    public record UpdateKeyboardCommand(UpdateKeyboardDto KeyboardDto) : IRequest<KeyboardDto>;
}
