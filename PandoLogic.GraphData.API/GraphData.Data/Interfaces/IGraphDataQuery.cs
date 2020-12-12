using GraphData.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphData.Data.Interfaces
{
    public interface IGraphDataQuery
    {
        Task<(IEnumerable<PositionsCountDto> positions, IEnumerable<ViewsCountDto> views)> GetGraphData(QueryFilter filter);
    }
}
