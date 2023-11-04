using CustomKeyboardsWeb.Application.Dtos.Members;
using CustomKeyboardsWeb.Application.Features.Responses.Members;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Members
{
    public class UpdateMemberCommand : Command<UpdateMemberCommandResponse>
    {
        public MemberDto MemberDto { get; set; }

        public UpdateMemberCommand(MemberDto model) => MemberDto = model;
    }
}
