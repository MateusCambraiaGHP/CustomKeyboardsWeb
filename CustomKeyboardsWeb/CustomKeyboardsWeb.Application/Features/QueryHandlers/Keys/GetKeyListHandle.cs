using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Keys;
using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Core.Messages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Keys
{
    public class GetKeyListHandle : Handler<GetKeyListQuery, GetKeyListQueryResponse>
    {
        private readonly IKeyRepository _keyRepository;
        private readonly IMapper _mapper;

        public GetKeyListHandle(
            IKeyRepository keyRepository,
            IMapper mapper)
            :base(mapper)
        {
            _keyRepository = keyRepository;
            _mapper = mapper;
        }

        public override async Task<GetKeyListQueryResponse> Handle(GetKeyListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listKey = await _keyRepository.GetAll();
                var listKeyMap = _mapper.Map<List<KeyViewModel>>(listKey);
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
