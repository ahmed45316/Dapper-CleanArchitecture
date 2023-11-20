using Dapper;
using DapperExample.Application.Abstractions;
using DapperExample.Domain.Models;
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
            var obj = new CommandProduct().SetProduct(request.action, request.product);
            var dp = new DynamicParameters(obj);
            dp.Add("ReturnId", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
            var result = await sqlConnection.ExecuteAsync("dbo.ManageProduct", dp, commandType: System.Data.CommandType.StoredProcedure);
            var id = dp.Get<int>("ReturnId");
            return id;
        }
    }
}
