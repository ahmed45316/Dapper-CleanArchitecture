using DapperExample.Application.Abstractions;
using DapperExample.Application.Persistance;

namespace DapperExample.Infrastructure.Persistance
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly ISqlConnectionFactory _sqlConnectionFactory;

        public BaseRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
    }
}
