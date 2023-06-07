using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Switch.Query.GetSwitchList
{
    public class GetSwitchListHandler : IRequestHandler<GetSwitchListQuery, List<SwitchDto>>
    {
        private readonly ISwitchService _switchService;

        public GetSwitchListHandler(ISwitchService switchService)
        {
            _switchService = switchService;
        }

        public async Task<List<SwitchDto>> Handle(GetSwitchListQuery request, CancellationToken cancellationToken)
        {
            var currentSwitch = await _switchService.GetAll();
            return currentSwitch;
        }
    }
}
