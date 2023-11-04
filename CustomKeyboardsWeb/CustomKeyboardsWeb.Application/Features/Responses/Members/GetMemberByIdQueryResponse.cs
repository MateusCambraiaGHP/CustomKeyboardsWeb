using CustomKeyboardsWeb.Application.Features.ViewModel.Members;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Members
{
    public class GetMemberByIdQueryResponse : BaseHandlerResponse
    {
        public MemberViewModel Member { get; set; }

        public GetMemberByIdQueryResponse()
            : base() { }

        public GetMemberByIdQueryResponse(MemberViewModel member)
            : base() => Member = member;

        public GetMemberByIdQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
