using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keyboards
{
    public class CreateKeyboardCommand : Command<CreateKeyboardCommandResponse>
    {
        public KeyboardViewModel KeyboardViewModel { get; set; }

        public CreateKeyboardCommand(KeyboardViewModel model) => KeyboardViewModel = model;
    }
}
