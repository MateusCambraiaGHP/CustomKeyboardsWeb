using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Switch.Query.GetSwitchById
{
    public record GetSwitchByIdQuery(int id) : IRequest<SwitchDto>;
}
