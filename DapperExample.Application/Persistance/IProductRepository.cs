using DapperExample.Application.Filters;
using DapperExample.Domain.Models;

namespace DapperExample.Application.Persistance
{
    public interface IProductRepository: IBaseRepository
    {
        Task<List<Product>> Query(ProductFilter filter);
        Task<int> Command(string action, Product product);
    }
}
