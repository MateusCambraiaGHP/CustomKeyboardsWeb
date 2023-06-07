using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Switch.Commands.CreateSwitch
{
    public class CreateSwitchHandler : IRequestHandler<CreateSwitchCommand, SwitchDto>
    {
        private readonly ISwitchService _switchService;

        public CreateSwitchHandler(ISwitchService switchService)
        {
            _switchService = switchService;
        }

        public async Task<SwitchDto> Handle(CreateSwitchCommand request, CancellationToken cancellationToken)
        {
            var currentSwitch = await _switchService.Save(request.SwitchDto);
            return currentSwitch;
        }
    }
}
