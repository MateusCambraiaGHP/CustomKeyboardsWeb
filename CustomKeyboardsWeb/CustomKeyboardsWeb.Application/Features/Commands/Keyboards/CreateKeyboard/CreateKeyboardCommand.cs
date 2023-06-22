using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keyboards.CreateKeyboard
{
    public record CreateKeyboardCommand(CreateKeyboardDto KeyboardDto) : IRequest<KeyboardDto>;
}
