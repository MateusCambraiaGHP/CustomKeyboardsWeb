using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keys.CreateKey
{
    public record CreateKeyCommand(CreateKeyDto createKeyDto) : IRequest<KeyDto>;
}
