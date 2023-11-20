using DapperExample.Domain.Models;
using MediatR;

namespace DapperExample.Application.Queries
{
    public record ProductCommand(string action, Product product) : IRequest<int>;
}
