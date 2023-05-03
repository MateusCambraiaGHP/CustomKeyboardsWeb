using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Key.Commands.UpdateKey
{
    public record UpdateKeyCommand(KeyDto keyDto) : IRequest<KeyDto>;
}
