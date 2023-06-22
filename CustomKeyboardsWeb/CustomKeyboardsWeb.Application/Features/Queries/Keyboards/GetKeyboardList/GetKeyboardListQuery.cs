using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keyboards.GetKeyboardList
{
    public record GetKeyboardListQuery() : IRequest<List<KeyboardDto>>;
}
