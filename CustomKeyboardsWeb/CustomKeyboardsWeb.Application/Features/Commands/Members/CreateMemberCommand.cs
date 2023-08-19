using CustomKeyboardsWeb.Application.Features.Responses.Members;
using CustomKeyboardsWeb.Application.Features.ViewModel.Members;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Members
{
    public class CreateMemberCommand : Command<CreateMemberCommandResponse>
    {
        public MemberViewModel MemberViewModel { get; set; }

        public CreateMemberCommand(MemberViewModel model) => MemberViewModel = model;
    }
}
