using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Key.Commands.UpdateKey
{
    public class UpdateKeyHandler : IRequestHandler<UpdateKeyCommand, KeyDto>
    {
        private readonly IKeyService _keyService;

        public UpdateKeyHandler(IKeyService keyService)
        {
            _keyService = keyService;
        }

        public async Task<KeyDto> Handle(UpdateKeyCommand request, CancellationToken cancellationToken)
        {
            var currentKey = await _keyService.Edit(request.keyDto);
            return currentKey;
        }
    }
}
