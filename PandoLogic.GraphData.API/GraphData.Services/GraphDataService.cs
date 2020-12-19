using GraphData.Data.Interfaces;
using GraphData.Data.Models;
using GraphData.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphData.Services
{
    public class GraphDataService: IGraphDataService
    {
        private readonly IGraphDataQuery _query;
        private readonly IPredictionsService _predictionsService;
        private readonly ILogger<GraphDataService> _logger;

        public GraphDataService(
            IGraphDataQuery query,
            IPredictionsService predictionsService,
            ILogger<GraphDataService> logger
        )
        {
            _query = query;
            _predictionsService = predictionsService;
            _logger = logger;
        }

        public async Task<IEnumerable<IEnumerable<object>>> GetGraohData(QueryFilter filter, string correlationId) {
            var (positions, views) = await _query.GetGraphData(filter);

            var result = new List<List<object>>
            {
                new List<object>() {
                    new { type = "date", label = "Dates" },
                    new { type = "number", label = "Active Jobs" },
                    new { type =  "number", label = "Cumulative job views" },
                    new { type =  "number", label = "Predicted job views" }
                }
            };

            for (var dt = filter.FromDate; dt <= filter.ToDate; dt = dt.AddDays(1))
            {
                var date = $"{dt:yyyy-MM-dd}";
                var queryDate = $"{dt:dd-MM-yyyy}";
                var positionCount = positions.Where(p => p.RequestDate == queryDate).SingleOrDefault()?.PositionsCount ?? 0;
                var viewsCount = views.Where(v => v.RequestDate == queryDate).SingleOrDefault()?.ViewsCount ?? 0;
                var viewsPrediction = _predictionsService.GetPrediction(viewsCount, dt);

                result.Add(
                    new List<object>() {
                        date,
                        positionCount,
                        viewsCount,
                        viewsPrediction
                    }
                );
            }

            return result;
        }
    }
}
