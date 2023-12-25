using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Keys;
using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Keys
{
    public class GetKeyListHandle : Handler<GetKeyListQuery, GetKeyListQueryResponse>
    {
        private readonly IKeyRepository _keyRepository;
        private readonly ICacheService _cacheService;

        public GetKeyListHandle(
            IKeyRepository keyRepository,
            IMapper mapper,
            ICacheService cacheService)
            : base(mapper)
        {
            _keyRepository = keyRepository;
            _cacheService = cacheService;
        }

        public override async Task<GetKeyListQueryResponse> Handle(GetKeyListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listKey = await _keyRepository.GetAsync(null, null, null);
                var listKeyMap = _mapper.Map<List<KeyViewModel>>(listKey);

                _cacheService.SetPost<KeyViewModel>(nameof(KeyViewModel), listKeyMap);
                return new GetKeyListQueryResponse(listKeyMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(GetKeyListQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
