using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keys.UpdateKey
{
    public record UpdateKeyCommand(UpdateKeyDto UpdateKeyDto) : IRequest<KeyDto>;
}
