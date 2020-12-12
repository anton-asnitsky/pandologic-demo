using AutoMapper;
using Commons.Controllers;
using Commons.Exceptions.Http;
using Commons.Validation.Interfaces;
using GraphData.API.Communication.Request;
using GraphData.Data.Models;
using GraphData.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphData.API.Controllers
{
    [Route("api/v1/graphdata")]
    public class GraphDataController : AppControllerBase<IGraphDataService>
    {
        public GraphDataController(
            IGraphDataService service,
            IMapper mapper,
            IRequestValidator requestValidator) :
            base(mapper, requestValidator, service)
        { }

        [HttpGet]
        public async Task<IActionResult> GetGraphData([FromQuery] GetGraphDataRequest request) {
            var validationResult = await RequestValidator.Validate(request);
            if (!validationResult.IsValid) { throw new BadRequestException(validationResult.Errors); }

            var queryFilter = Mapper.Map<GetGraphDataRequest, QueryFilter>(request);

            var graphData = await Service.GetGraohData(queryFilter, CorrelationId);

            return Ok(graphData);
        }
    }
}
