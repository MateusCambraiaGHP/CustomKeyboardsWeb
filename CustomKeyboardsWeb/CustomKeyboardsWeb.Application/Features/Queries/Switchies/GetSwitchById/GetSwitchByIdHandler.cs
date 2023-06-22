using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Switchies.GetSwitchById
{
    public class GetSwitchByIdHandler : IRequestHandler<GetSwitchByIdQuery, SwitchDto>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;

        public GetSwitchByIdHandler(
            ISwitchRepository switchRepository,
            IMapper mapper)
        {
            _switchRepository = switchRepository;
            _mapper = mapper;
        }

        public async Task<SwitchDto> Handle(GetSwitchByIdQuery request, CancellationToken cancellationToken)
        {
            var currentSwitch = await _switchRepository.FindById(request.id);
            var switchMap = _mapper.Map<SwitchDto>(currentSwitch);
            return switchMap;
        }
    }
}
