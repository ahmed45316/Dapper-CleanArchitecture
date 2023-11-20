using Dapper;
using DapperExample.Application.Abstractions;
using DapperExample.Domain.Models;
using MediatR;
using Microsoft.Data.SqlClient;

namespace DapperExample.Application.Queries
{
    internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetAllProductsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var parameters = new { FilterName = request.name, FilterPrice = request.price };
            await using SqlConnection sqlConnection = _sqlConnectionFactory.CreateConnection();
            var products = await sqlConnection.QueryAsync<Product>("dbo.GetProducts", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return products.ToList();
        }
    }
}
