using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Switch.Query.GetSwitchById
{
    public class GetSwitchByIdHandler : IRequestHandler<GetSwitchByIdQuery, SwitchDto>
    {
        private readonly ISwitchService _switchService;

        public GetSwitchByIdHandler(ISwitchService switchService)
        {
            _switchService = switchService;
        }

        public async Task<SwitchDto> Handle(GetSwitchByIdQuery request, CancellationToken cancellationToken)
        {
            var currentSwitch = await _switchService.FindByIdAsync(request.id);
            return currentSwitch;
        }
    }
}
