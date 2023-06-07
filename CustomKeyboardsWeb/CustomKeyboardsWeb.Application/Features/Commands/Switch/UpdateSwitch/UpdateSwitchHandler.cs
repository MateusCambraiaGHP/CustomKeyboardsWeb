using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Switch.Commands.UpdateSwitch
{
    public class UpdateSwitchHandler : IRequestHandler<UpdateSwitchCommand, SwitchDto>
    {
        private readonly ISwitchService _switchService;

        public UpdateSwitchHandler(ISwitchService switchService)
        {
            _switchService = switchService;
        }

        public async Task<SwitchDto> Handle(UpdateSwitchCommand request, CancellationToken cancellationToken)
        {
            var currentSwitch = await _switchService.Edit(request.SwitchDto);
            return currentSwitch;
        }
    }
}
