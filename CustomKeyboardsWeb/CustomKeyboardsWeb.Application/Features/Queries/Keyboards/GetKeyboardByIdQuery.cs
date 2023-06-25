using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keyboards
{
    public class GetKeyboardByIdQuery : Query<GetKeyboardByIdQueryResponse> 
    {
        public int IdKeyboard { get; set; }
        public GetKeyboardByIdQuery(int idKeyboard) => IdKeyboard = idKeyboard;
    }
}
