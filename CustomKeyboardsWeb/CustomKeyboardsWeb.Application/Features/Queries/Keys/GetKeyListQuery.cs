using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keys
{
    public class GetKeyListQuery : Query<GetKeyListQueryResponse>
    {
        public GetKeyListQuery() { }
    }
}
