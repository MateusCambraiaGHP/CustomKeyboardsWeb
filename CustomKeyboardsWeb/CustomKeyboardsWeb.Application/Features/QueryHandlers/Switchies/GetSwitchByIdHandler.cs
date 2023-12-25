using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Switchies;
using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Switchies
{
    public class GetSwitchByIdHandler : Handler<GetSwitchByIdQuery, GetSwitchByIdQueryResponse>
    {
        private readonly ISwitchRepository _switchRepository;

        public GetSwitchByIdHandler(
            ISwitchRepository switchRepository,
            IMapper mapper)
            : base(mapper)
        {
            _switchRepository = switchRepository;
        }

        public override async Task<GetSwitchByIdQueryResponse> Handle(GetSwitchByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var currentSwitch = await _switchRepository.GetAsync(kb => kb.Id == request.IdSwitch, null, null);
                var switchMap = _mapper.Map<SwitchViewModel>(currentSwitch);
                return new GetSwitchByIdQueryResponse(switchMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(GetSwitchByIdQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
