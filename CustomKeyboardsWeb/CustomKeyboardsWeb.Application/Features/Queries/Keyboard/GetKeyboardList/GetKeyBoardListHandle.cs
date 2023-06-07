using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Keyboard.Query.GetKeyboardList
{
    public class GetKeyBoardListHandle : IRequestHandler<GetKeyboardListQuery, List<KeyboardDto>>
    {
        private readonly IKeyboardService _keyboardService;

        public GetKeyBoardListHandle(IKeyboardService keyboardService)
        {
            _keyboardService = keyboardService;
        }

        public Task<List<KeyboardDto>> Handle(GetKeyboardListQuery request, CancellationToken cancellationToken)
        {
            var currentKeyboardList = _keyboardService.GetAll();
            return currentKeyboardList;
        }
    }
}
