using CustomKeyboardsWeb.Application.Features.Responses.Members;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Members
{
    public class GetMemberByIdQuery : Query<GetMemberByIdQueryResponse>
    {
        public Guid IdMember { get; set; }
        public GetMemberByIdQuery(Guid idMember) => IdMember = idMember;
    }
}
