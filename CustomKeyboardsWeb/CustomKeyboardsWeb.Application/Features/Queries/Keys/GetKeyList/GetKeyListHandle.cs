using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keys.GetKeyList
{
    public class GetKeyListHandle : IRequestHandler<GetKeyListQuery, List<KeyDto>>
    {
        private readonly IKeyRepository _keyRepository;
        private readonly IMapper _mapper;

        public GetKeyListHandle(
            IKeyRepository keyRepository,
            IMapper mapper)
        {
            _keyRepository = keyRepository;
            _mapper = mapper;
        }

        public async Task<List<KeyDto>> Handle(GetKeyListQuery request, CancellationToken cancellationToken)
        {
            var listKey = await _keyRepository.GetAll();
            var listKeyMap = _mapper.Map<List<KeyDto>>(listKey);
            return listKeyMap;
        }
    }
}
