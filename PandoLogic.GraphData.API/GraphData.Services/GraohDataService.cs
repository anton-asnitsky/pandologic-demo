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
    public class GraohDataService: IGraphDataService
    {
        private readonly IGraphDataQuery _query;
        private readonly IPredictionsService _predictionsService;
        private readonly ILogger<GraohDataService> _logger;

        public GraohDataService(
            IGraphDataQuery query,
            IPredictionsService predictionsService,
            ILogger<GraohDataService> logger
        )
        {
            _query = query;
            _predictionsService = predictionsService;
            _logger = logger;
        }

        public async Task<IEnumerable<IEnumerable<string>>> GetGraohData(QueryFilter filter, string correlationId) {
            var (positions, views) = await _query.GetGraphData(filter);

            var result = new List<List<string>>
            {
                new List<string>() {
                    "Dates",
                    "Active Jobs",
                    "Cumulative job views",
                    "Predicted job views"
                }
            };

            for (var dt = filter.FromDate; dt <= filter.ToDate; dt = dt.AddDays(1))
            {
                var date = $"{dt:dd-MM-yyyy}";
                var positionCount = positions.Where(p => p.RequestDate == date).SingleOrDefault()?.PositionsCount ?? 0;
                var viewsCount = views.Where(v => v.RequestDate == date).SingleOrDefault()?.ViewsCount ?? 0;
                var viewsPrediction = _predictionsService.GetPrediction(viewsCount, dt);

                result.Add(
                    new List<string>() {
                        date,
                        $"{positionCount}",
                        $"{viewsCount}",
                        $"{viewsPrediction}"
                    }
                );
            }

            return result;
        }
    }
}
