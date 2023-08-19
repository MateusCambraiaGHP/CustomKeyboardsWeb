using CustomKeyboardsWeb.Application.Features.ViewModel.Members;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Members
{
    public class UpdateMemberCommandResponse : BaseHandlerResponse
    {
        public MemberViewModel Member { get; set; }

        public UpdateMemberCommandResponse() { }

        public UpdateMemberCommandResponse(MemberViewModel member)
            : base() => Member = member;

        public UpdateMemberCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
