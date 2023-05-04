using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Keyboard.Query.GetKeyboardById
{
    public class GetKeyboardByIdHandler : IRequestHandler<GetKeyboardByIdQuery, KeyboardDto>
    {
        private readonly IKeyboardService _keyboardService;

        public GetKeyboardByIdHandler(IKeyboardService keyboardService)
        {
            _keyboardService = keyboardService;
        }

        public Task<KeyboardDto> Handle(GetKeyboardByIdQuery request, CancellationToken cancellationToken)
        {
            var currentKeyboard = _keyboardService.FindByIdAsync(request.Id);
            return currentKeyboard;
        }
    }
}
