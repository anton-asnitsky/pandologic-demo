using GraphData.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using GraphData.Data.Models;
using System.Threading.Tasks;

namespace GraphData.Data.Stores
{
    public class GraohDataQuery : IGraphDataQuery
    {
        public IDbConnection _connection;

        public GraohDataQuery(IDbConnectionFactory connectionFactory)
        {
            _connection = connectionFactory.CreateDbConnection(Commons.Enums.DatabaseConnectionTypes.Query);
        }

        public async Task<(IEnumerable<PositionsCountDto> positions, IEnumerable<ViewsCountDto> views)> GetGraphData(QueryFilter filter) {
            var dataSets = await _connection.QueryMultipleAsync(
               "sp_GetGraphData",
                new { filter.FromDate, filter.ToDate },
               commandType: CommandType.StoredProcedure);

            var positions = await dataSets.ReadAsync<PositionsCountDto>();
            var views = await dataSets.ReadAsync<ViewsCountDto>();

            return (positions, views);
        }
    }
}
