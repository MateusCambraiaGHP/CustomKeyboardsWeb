using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Queries.Switchies;
using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Core.Messages;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Switchies
{
    public class GetSwitchListHandler : Handler<GetSwitchListQuery, GetSwitchListQueryResponse>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;

        public GetSwitchListHandler(
            ISwitchRepository switchRepository,
            IMapper mapper)
            :base(mapper)
        {
            _switchRepository = switchRepository;
            _mapper = mapper;
        }

        public override async Task<GetSwitchListQueryResponse> Handle(GetSwitchListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listSwitch = await _switchRepository.GetAll();
                var listSwitchMap = _mapper.Map<List<SwitchViewModel>>(listSwitch);
                return new GetSwitchListQueryResponse(listSwitchMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Task<List<ValidationFailure>> Validate(GetSwitchListQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
