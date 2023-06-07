using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Key.Query.GetKeyList
{
    public class GetKeyListHandle : IRequestHandler<GetKeyListQuery, List<KeyDto>>
    {
        private readonly IKeyService _keyService;

        public GetKeyListHandle(IKeyService keyService)
        {
            _keyService = keyService;
        }

        public async Task<List<KeyDto>> Handle(GetKeyListQuery request, CancellationToken cancellationToken)
        {
            var currentKeyList = await _keyService.GetAll();
            return currentKeyList;
        }
    }
}
