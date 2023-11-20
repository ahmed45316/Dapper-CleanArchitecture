using DapperExample.Domain.Models;
using MediatR;

namespace DapperExample.Application.Queries
{
    public record GetAllProductsQuery(string? name = null, decimal? price = null) : IRequest<List<Product>>;
}
