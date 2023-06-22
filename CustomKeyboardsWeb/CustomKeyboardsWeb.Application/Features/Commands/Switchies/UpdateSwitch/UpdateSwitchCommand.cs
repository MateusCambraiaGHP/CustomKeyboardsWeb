using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Switchies.UpdateSwitch
{
    public record UpdateSwitchCommand(UpdateSwitchDto SwitchDto) : IRequest<SwitchDto>;
}
