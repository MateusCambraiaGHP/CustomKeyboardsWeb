using CustomKeyboardsWeb.Application.Features.Responses.Members;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Members
{
    public class GetMemberByIdQuery : Query<GetMemberByIdQueryResponse>
    {
        public Guid IdMember { get; set; }
        public GetMemberByIdQuery(Guid idMember) => IdMember = idMember;
    }
}
