using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Switchies.CreateSwitch
{
    public record CreateSwitchCommand(CreateSwitchDto SwitchDto) : IRequest<SwitchDto>;
}
