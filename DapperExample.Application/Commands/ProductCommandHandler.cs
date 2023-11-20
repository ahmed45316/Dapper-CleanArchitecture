using Dapper;
using DapperExample.Application.Abstractions;
using MediatR;
using Microsoft.Data.SqlClient;

namespace DapperExample.Application.Queries
{
    internal class ProductCommandHandler : IRequestHandler<ProductCommand, int>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public ProductCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<int> Handle(ProductCommand request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _sqlConnectionFactory.CreateConnection();
            var result = await sqlConnection.ExecuteAsync("dbo.ManageProduct", request.product, commandType: System.Data.CommandType.StoredProcedure);
            return request.product.Id;
        }
    }
}
