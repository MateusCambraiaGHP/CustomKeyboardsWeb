using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Switchies.GetSwitchList
{
    public class GetSwitchListHandler : IRequestHandler<GetSwitchListQuery, List<SwitchDto>>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;

        public GetSwitchListHandler(
            ISwitchRepository switchRepository,
            IMapper mapper)
        {
            _switchRepository = switchRepository;
            _mapper = mapper;
        }

        public async Task<List<SwitchDto>> Handle(GetSwitchListQuery request, CancellationToken cancellationToken)
        {
            var listSwitch = await _switchRepository.GetAll();
            var listSwitchMap = _mapper.Map<List<SwitchDto>>(listSwitch);
            return listSwitchMap;
        }
    }
}
