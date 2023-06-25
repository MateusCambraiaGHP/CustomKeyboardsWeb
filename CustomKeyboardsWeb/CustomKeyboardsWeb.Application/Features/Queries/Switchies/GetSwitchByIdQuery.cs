using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Switchies
{
    public class GetSwitchByIdQuery : Query<GetSwitchByIdQueryResponse>
    {
        public int IdSwitch { get; set; }
        public GetSwitchByIdQuery(int idSwitch) => IdSwitch = idSwitch;
    }
}
