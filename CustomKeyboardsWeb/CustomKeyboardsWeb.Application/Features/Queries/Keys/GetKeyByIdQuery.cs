using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keys
{
    public class GetKeyByIdQuery : Query<GetKeyByIdQueryResponse>
    {
        public Guid IdKey { get; set; }
        public GetKeyByIdQuery(Guid idKey) => IdKey = idKey;
    }
}
