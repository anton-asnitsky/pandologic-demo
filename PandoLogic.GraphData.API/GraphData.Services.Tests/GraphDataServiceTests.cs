using GraphData.Data.Interfaces;
using GraphData.Data.Models;
using GraphData.Services;
using GraphData.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GraphData.Tests
{
    public class GraphDataServiceTests
    {
        private readonly Mock<IGraphDataQuery> _query;
        private readonly Mock<IPredictionsService> _predictionsService;
        private readonly Mock<ILogger<GraphDataService>> _logger;

        public GraphDataServiceTests()
        {
            _query = new Mock<IGraphDataQuery>();
            _predictionsService = new Mock<IPredictionsService>();
            _logger = new Mock<ILogger<GraphDataService>>();
        }

        [Fact]
        public async Task GraphDataServicePassesTest() {
            var filterMock = new QueryFilter() {
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now,
                PageNumber = 1,
                PageSize = 25
            };

            var service = new GraphDataService(
                _query.Object,
                _predictionsService.Object,
                _logger.Object
            );

            _query.Setup(q => q.GetGraphData(
                It.IsAny<QueryFilter>()
            )).ReturnsAsync((
                new List<PositionsCountDto>() { 
                    new PositionsCountDto()
                    {
                        PositionsCount = new Random().Next(1, 100),
                        RequestDate = $"{filterMock.FromDate:dd-MM-yyyy}"
                    },
                    new PositionsCountDto()
                    {
                        PositionsCount = new Random().Next(1, 100),
                        RequestDate = $"{filterMock.ToDate:dd-MM-yyyy}"
                    },
                }, 
                new List<ViewsCountDto>() { 
                    new ViewsCountDto(){ 
                        RequestDate = $"{filterMock.FromDate:dd-MM-yyyy}",
                        ViewsCount = new Random().Next(1, 100)
                    },
                    new ViewsCountDto(){
                        RequestDate = $"{filterMock.ToDate:dd-MM-yyyy}",
                        ViewsCount = new Random().Next(1, 100)
                    }
                })
            );
            _predictionsService.Setup(p => p.GetPrediction(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(It.IsAny<int>());

            await service.GetGraohData(filterMock, $"{Guid.NewGuid()}");

            _query.Verify(q => q.GetGraphData(It.IsAny<QueryFilter>()), Times.Once);
            _predictionsService.Verify(prop => prop.GetPrediction(It.IsAny<int>(), It.IsAny<DateTime>()), Times.AtLeastOnce);

            await Task.CompletedTask;
        }
    }
}
