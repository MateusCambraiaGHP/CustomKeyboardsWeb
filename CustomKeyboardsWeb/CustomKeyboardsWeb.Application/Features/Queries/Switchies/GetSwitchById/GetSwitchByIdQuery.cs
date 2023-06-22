using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Switchies.GetSwitchById
{
    public record GetSwitchByIdQuery(int id) : IRequest<SwitchDto>;
}
