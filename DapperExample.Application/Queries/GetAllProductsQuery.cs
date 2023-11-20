using DapperExample.Domain.Models;
using MediatR;

namespace DapperExample.Application.Queries
{
    public record GetAllProductsQuery(int? id = null, string? name = null, decimal? price = null) : IRequest<List<Product>>;
}
