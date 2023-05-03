using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Key.Commands.CreateKey
{
    public record CreateKeyCommand(KeyDto keyDto): IRequest<KeyDto>;
}
