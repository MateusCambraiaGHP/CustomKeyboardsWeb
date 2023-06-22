using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keys.GetKeyById
{
    public class GetKeyByIdHandle : IRequestHandler<GetKeyByIdQuery, KeyDto>
    {
        private readonly IKeyRepository _keyRepository;
        private readonly IMapper _mapper;

        public GetKeyByIdHandle(
            IKeyRepository keyRepository,
            IMapper mapper)
        {
            _keyRepository = keyRepository;
            _mapper = mapper;
        }

        public async Task<KeyDto> Handle(GetKeyByIdQuery request, CancellationToken cancellationToken)
        {
            var currentKey = await _keyRepository.FindById(request.id);
            var keyMap = _mapper.Map<KeyDto>(currentKey);
            return keyMap;
        }
    }
}
