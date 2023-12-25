using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Switchies;
using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Switchies
{
    public class GetSwitchListHandler : Handler<GetSwitchListQuery, GetSwitchListQueryResponse>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly ICacheService _cacheService;

        public GetSwitchListHandler(
            ISwitchRepository switchRepository,
            IMapper mapper,
            ICacheService cacheService)
            : base(mapper)
        {
            _switchRepository = switchRepository;
            _cacheService = cacheService;
        }

        public override async Task<GetSwitchListQueryResponse> Handle(GetSwitchListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listSwitch = await _switchRepository.GetAsync(null, null, null);
                var listSwitchMap = _mapper.Map<List<SwitchViewModel>>(listSwitch);

                _cacheService.SetPost<SwitchViewModel>(nameof(SwitchViewModel), listSwitchMap);
                return new GetSwitchListQueryResponse(listSwitchMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(GetSwitchListQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
