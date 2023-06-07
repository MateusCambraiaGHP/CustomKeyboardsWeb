using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Key.Commands.UpdateKey
{
    public record UpdateKeyCommand(UpdateKeyDto UpdateKeyDto) : IRequest<KeyDto>;
}
