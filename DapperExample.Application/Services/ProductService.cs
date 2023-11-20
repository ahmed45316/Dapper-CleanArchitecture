using DapperExample.Application.Filters;
using DapperExample.Application.Persistance;
using DapperExample.Domain.Models;

namespace DapperExample.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAll()
        {
            var filter = new ProductFilter();
            List<Product> result = await _repository.Query(filter);
            return result;
        }
        public async Task<Product?> GetById(int id)
        {
            var filter = new ProductFilter(id);
            List<Product> result = await _repository.Query(filter);
            return result.FirstOrDefault();
        }
        public async Task<int> Add(Product product) => await _repository.Command("INSERT", product);
        public async Task<int> Edit(Product product) => await _repository.Command("UPDATE", product);
        public async Task Delete(int id) => await _repository.Command("UPDATE", new Product { Id = id });
    }
}
