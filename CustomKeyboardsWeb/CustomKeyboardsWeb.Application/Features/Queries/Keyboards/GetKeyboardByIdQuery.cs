using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keyboards
{
    public class GetKeyboardByIdQuery : Query<GetKeyboardByIdQueryResponse> 
    {
        public Guid IdKeyboard { get; set; }
        public GetKeyboardByIdQuery(Guid idKeyboard) => IdKeyboard = idKeyboard;
    }
}
