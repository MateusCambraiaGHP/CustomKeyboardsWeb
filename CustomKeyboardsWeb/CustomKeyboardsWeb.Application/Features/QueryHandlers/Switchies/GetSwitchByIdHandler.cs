using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Queries.Switchies;
using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Switchies
{
    public class GetSwitchByIdHandler : Handler<GetSwitchByIdQuery, GetSwitchByIdQueryResponse>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;

        public GetSwitchByIdHandler(
            ISwitchRepository switchRepository,
            IMapper mapper)
            :base(mapper)
        {
            _switchRepository = switchRepository;
            _mapper = mapper;
        }

        public override async Task<GetSwitchByIdQueryResponse> Handle(GetSwitchByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var currentSwitch = await _switchRepository.FindById(request.IdSwitch);
                var switchMap = _mapper.Map<SwitchViewModel>(currentSwitch);
                return new GetSwitchByIdQueryResponse(switchMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Task<List<ValidationFailure>> Validate(GetSwitchByIdQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
