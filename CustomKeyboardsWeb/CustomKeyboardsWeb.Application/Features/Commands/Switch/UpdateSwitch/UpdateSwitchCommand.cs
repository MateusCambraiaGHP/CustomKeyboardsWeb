using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Switch.Commands.UpdateSwitch
{
    public record UpdateSwitchCommand(UpdateSwitchDto SwitchDto): IRequest<SwitchDto>;
}
