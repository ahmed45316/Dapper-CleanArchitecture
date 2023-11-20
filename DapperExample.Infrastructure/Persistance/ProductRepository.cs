using Dapper;
using DapperExample.Application.Abstractions;
using DapperExample.Application.Filters;
using DapperExample.Application.Persistance;
using DapperExample.Domain.Models;
using Microsoft.Data.SqlClient;

namespace DapperExample.Infrastructure.Persistance
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ISqlConnectionFactory sqlConnectionFactory) : base(sqlConnectionFactory)
        {
        }

        public async Task<List<Product>> Query(ProductFilter filter)
        {
            var parameters = new { Id = filter.id, FilterName = filter.name, FilterPrice = filter.price };
            await using SqlConnection sqlConnection = _sqlConnectionFactory.CreateConnection();
            var products = await sqlConnection.QueryAsync<Product>("dbo.GetProducts", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return products.ToList();
        }
        public async Task<int> Command(string action, Product product)
        {
            await using SqlConnection sqlConnection = _sqlConnectionFactory.CreateConnection();
            var obj = new CommandProduct().SetProduct(action, product);
            var dp = new DynamicParameters(obj);
            dp.Add("ReturnId", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
            var result = await sqlConnection.ExecuteAsync("dbo.ManageProduct", dp, commandType: System.Data.CommandType.StoredProcedure);
            var id = dp.Get<int>("ReturnId");
            return id;
        }
    }
}
