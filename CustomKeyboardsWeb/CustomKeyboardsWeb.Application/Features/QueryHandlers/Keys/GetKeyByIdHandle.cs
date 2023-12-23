using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Keys;
using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Keys
{
    public class GetKeyByIdHandle : Handler<GetKeyByIdQuery, GetKeyByIdQueryResponse>
    {
        private readonly IKeyRepository _keyRepository;
        private readonly IMapper _mapper;

        public GetKeyByIdHandle(
            IKeyRepository keyRepository,
            IMapper mapper)
            : base(mapper)
        {
            _keyRepository = keyRepository;
            _mapper = mapper;
        }

        public override async Task<GetKeyByIdQueryResponse> Handle(GetKeyByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var currentKey = await _keyRepository.GetAsync(k => k.Id == request.IdKey, null, null);
                var keyMap = _mapper.Map<KeyViewModel>(currentKey);
                return new GetKeyByIdQueryResponse(keyMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(GetKeyByIdQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
