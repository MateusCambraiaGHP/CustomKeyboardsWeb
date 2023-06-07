using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Switch.Query.GetSwitchList
{
    public record GetSwitchListQuery : IRequest<List<SwitchDto>>;
}
