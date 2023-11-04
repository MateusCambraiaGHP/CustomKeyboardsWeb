using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Switchies
{
    public class GetSwitchByIdQuery : Query<GetSwitchByIdQueryResponse>
    {
        public Guid IdSwitch { get; set; }
        public GetSwitchByIdQuery(Guid idSwitch) => IdSwitch = idSwitch;
    }
}
