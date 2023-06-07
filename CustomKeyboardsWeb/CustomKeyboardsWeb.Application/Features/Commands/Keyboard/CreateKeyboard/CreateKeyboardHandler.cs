using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Keyboard.Commands.CreateKeyboard
{
    public class CreateKeyboardHandler : IRequestHandler<CreateKeyboardCommand, KeyboardDto>
    {
        private readonly IKeyboardService _keyboardService;

        public CreateKeyboardHandler(IKeyboardService keyboardService)
        {
            _keyboardService = keyboardService;
        }

        public Task<KeyboardDto> Handle(CreateKeyboardCommand request, CancellationToken cancellationToken)
        {
            var currentKeyboard = _keyboardService.Save(request.KeyboardDto);
            return currentKeyboard;
        }
    }
}
