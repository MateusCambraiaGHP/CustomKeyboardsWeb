using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keyboards.GetKeyboardById
{
    public record GetKeyboardByIdQuery(int Id) : IRequest<KeyboardDto>;
}
