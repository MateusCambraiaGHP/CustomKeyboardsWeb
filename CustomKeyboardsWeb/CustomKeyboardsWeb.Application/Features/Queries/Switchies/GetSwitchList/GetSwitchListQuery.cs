using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Switchies.GetSwitchList
{
    public record GetSwitchListQuery : IRequest<List<SwitchDto>>;
}
