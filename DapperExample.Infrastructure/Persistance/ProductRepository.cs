using DapperExample.Application.Persistance;
using DapperExample.Domain.Models;

namespace DapperExample.Infrastructure.Persistance
{
    public class ProductRepository : IProductRepository
    {

        public ProductRepository()
        {
           
        }

        public async Task<List<Product>> GetAll()
        {       
            return null;
        }
    }
}
