using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keyboards
{
    public class UpdateKeyboardCommand : Command<UpdateKeyboardCommandResponse>
    {
        public KeyboardViewModel KeyboardViewModel { get; set; }

        public UpdateKeyboardCommand(KeyboardViewModel model) => KeyboardViewModel = model;
    }
}
