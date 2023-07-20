using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keys
{
    public class GetKeyByIdQuery : Query<GetKeyByIdQueryResponse>
    {
        public int IdKey { get; set; }
        public GetKeyByIdQuery(int idKey) => IdKey = idKey;
    }
}
