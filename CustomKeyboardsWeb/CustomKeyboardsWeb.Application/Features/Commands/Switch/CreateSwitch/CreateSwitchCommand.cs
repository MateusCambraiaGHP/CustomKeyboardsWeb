using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Switch.Commands.CreateSwitch
{
    public record CreateSwitchCommand(CreateSwitchDto SwitchDto) : IRequest<SwitchDto>;
}
