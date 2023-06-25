using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keyboards
{
    public class GetKeyboardListQuery : Query<GetKeyboardListQueryResponse>
    {
        public GetKeyboardListQuery() { }
    }
}
