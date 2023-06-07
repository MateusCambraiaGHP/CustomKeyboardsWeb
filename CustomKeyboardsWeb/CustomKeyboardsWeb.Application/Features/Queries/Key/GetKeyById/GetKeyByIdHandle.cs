using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Key.Query.GetKeyById
{
    public class GetKeyByIdHandle : IRequestHandler<GetKeyByIdQuery, KeyDto>
    {
        private readonly IKeyService _keyService;

        public GetKeyByIdHandle(IKeyService keyService)
        {
            _keyService = keyService;
        }

        public async Task<KeyDto> Handle(GetKeyByIdQuery request, CancellationToken cancellationToken)
        {
            var currentKey = await _keyService.FindByIdAsync(request.id);
            return currentKey;
        }
    }
}
