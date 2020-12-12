using GraphData.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphData.Services.Interfaces
{
    public interface IGraphDataService
    {
        Task<IEnumerable<IEnumerable<string>>> GetGraohData(QueryFilter filter1, string correlationId);
    }
}
