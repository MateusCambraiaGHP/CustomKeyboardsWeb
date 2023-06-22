using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keys.GetKeyById
{
    public record GetKeyByIdQuery(int id) : IRequest<KeyDto>;
}
