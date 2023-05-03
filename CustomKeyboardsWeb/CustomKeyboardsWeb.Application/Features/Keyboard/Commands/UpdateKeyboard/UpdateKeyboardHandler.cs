using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Keyboard.Commands.UpdateKeyboard
{
    public class UpdateKeyboardHandler : IRequestHandler<UpdateKeyboardCommand, KeyboardDto>
    {
        private readonly IKeyboardService _keyboardService;

        public UpdateKeyboardHandler(IKeyboardService keyboardService)
        {
            _keyboardService = keyboardService;
        }

        public Task<KeyboardDto> Handle(UpdateKeyboardCommand request, CancellationToken cancellationToken)
        {
            var currentKeyboard = _keyboardService.Edit(request.KeyboardDto);
            return currentKeyboard;
        }
    }
}
