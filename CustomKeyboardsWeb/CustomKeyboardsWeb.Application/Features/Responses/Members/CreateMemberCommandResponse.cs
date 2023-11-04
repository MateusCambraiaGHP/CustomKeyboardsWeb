using CustomKeyboardsWeb.Application.Features.ViewModel.Members;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Members
{
    public class CreateMemberCommandResponse : BaseHandlerResponse
    {
        public MemberViewModel Member { get; set; }

        public CreateMemberCommandResponse() { }

        public CreateMemberCommandResponse(MemberViewModel member)
            : base() => Member = member;

        public CreateMemberCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
