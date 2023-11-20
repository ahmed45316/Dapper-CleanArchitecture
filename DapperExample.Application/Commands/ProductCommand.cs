using DapperExample.Domain.Models;
using MediatR;

namespace DapperExample.Application.Queries
{
    public record ProductCommand(CommandProduct product) : IRequest<int>;
}
