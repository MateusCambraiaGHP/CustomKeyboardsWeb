using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Queries.Keys;
using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
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
            :base(mapper)
        {
            _keyRepository = keyRepository;
            _mapper = mapper;
        }

        public override async Task<GetKeyByIdQueryResponse> Handle(GetKeyByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var currentKey = await _keyRepository.FindById(request.IdKey);
                var keyMap = _mapper.Map<KeyViewModel>(currentKey);
                return new GetKeyByIdQueryResponse(keyMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Task<List<ValidationFailure>> Validate(GetKeyByIdQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
