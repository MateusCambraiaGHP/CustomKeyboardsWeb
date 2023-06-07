using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Key.Query.GetKeyById
{
    public record GetKeyByIdQuery(int id) : IRequest<KeyDto>;
}
