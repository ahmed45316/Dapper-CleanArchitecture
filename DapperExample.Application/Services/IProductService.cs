using DapperExample.Domain.Models;

namespace DapperExample.Application.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product?> GetById(int id);
        Task<int> Add(Product product);
        Task<int> Edit(Product product);
        Task Delete(int id);
    }
}
