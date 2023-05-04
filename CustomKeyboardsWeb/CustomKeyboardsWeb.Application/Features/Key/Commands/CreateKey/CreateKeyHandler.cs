using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Key.Commands.CreateKey
{
    public class CreateKeyHandler : IRequestHandler<CreateKeyCommand, KeyDto>
    {
        private readonly IKeyService _keyService;

        public CreateKeyHandler(IKeyService keyService)
        {
            _keyService = keyService;
        }

        public async Task<KeyDto> Handle(CreateKeyCommand request, CancellationToken cancellationToken)
        {
            var currentKey = await _keyService.Save(request.keyDto);
            return currentKey;
        }
    }
}
