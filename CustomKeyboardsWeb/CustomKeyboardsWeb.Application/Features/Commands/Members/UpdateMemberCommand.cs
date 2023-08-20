using CustomKeyboardsWeb.Application.Features.Responses.Members;
using CustomKeyboardsWeb.Application.Features.ViewModel.Members;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Members
{
    public class UpdateMemberCommand : Command<UpdateMemberCommandResponse>
    {
        public MemberViewModel MemberViewModel { get; set; }

        public UpdateMemberCommand(MemberViewModel model) => MemberViewModel = model;
    }
}
