using CustomKeyboardsWeb.Application.Features.ViewModel.Members;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Members
{
    public class GetMemberListQueryResponse : BaseHandlerResponse
    {
        public List<MemberViewModel> Members { get; set; }

        public GetMemberListQueryResponse()
            : base() { }

        public GetMemberListQueryResponse(List<MemberViewModel> memberList)
            : base() => Members = memberList;

        public GetMemberListQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
