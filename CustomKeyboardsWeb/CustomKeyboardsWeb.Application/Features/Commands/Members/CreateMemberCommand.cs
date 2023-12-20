using CustomKeyboardsWeb.Application.Dtos.Members;
using CustomKeyboardsWeb.Application.Features.Responses.Members;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Members
{
    public class CreateMemberCommand : Command<CreateMemberCommandResponse>
    {
        public CreateMemberDto MemberDto { get; init; }

        public CreateMemberCommand(CreateMemberDto model) => MemberDto = model;
    }
}
