using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Key.Commands.CreateKey
{
    public record CreateKeyCommand(CreateKeyDto keyDto): IRequest<KeyDto>;
}
