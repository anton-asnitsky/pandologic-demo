using FluentAssertions;
using GraphData.API.Communication.Request;
using GraphData.API.Validators;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GraphData.Services.Tests
{
    public class RequestValidatorsTests
    {
        private readonly GetGraphDataRequestValidator _validator;

        public RequestValidatorsTests()
        {
            _validator = new GetGraphDataRequestValidator();
        }

        [Fact]
        public async Task GetGraphOtionsValidatorPassesTest() {
            var mockRequest = new GetGraphDataRequest
            {
                FromDate = DateTime.Parse("2020-12-19 00:00:00"),
                ToDate = DateTime.Parse("2020-12-21 00:00:00"),
                PageNumber = 2,
                PageSize = 25
            };

            var result = await _validator.ValidateAsync(mockRequest);

            result.IsValid.Should().BeTrue();
            result.Errors.Count.Should().Be(0);

            await Task.CompletedTask;
        }

        [Fact]
        public async Task GetGraphOtionsValidatorFailedOnEmptyFromDateTest()
        {
            var mockRequest = new GetGraphDataRequest
            {
                FromDate = default,
                ToDate = DateTime.Parse("2020-12-21 00:00:00"),
                PageNumber = 2,
                PageSize = 25
            };

            var result = await _validator.ValidateAsync(mockRequest);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);

            await Task.CompletedTask;
        }

        [Fact]
        public async Task GetGraphOtionsValidatorFailedOnEmptyToDateTest()
        {
            var mockRequest = new GetGraphDataRequest
            {
                FromDate = DateTime.Parse("2020-12-19 00:00:00"),
                ToDate = default,
                PageNumber = 2,
                PageSize = 25
            };

            var result = await _validator.ValidateAsync(mockRequest);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(2);

            await Task.CompletedTask;
        }

        [Fact]
        public async Task GetGraphOtionsValidatorFailedOnOverlappingDateTest()
        {
            var mockRequest = new GetGraphDataRequest
            {
                FromDate = DateTime.Parse("2020-12-21 00:00:00"),
                ToDate = DateTime.Parse("2020-12-19 00:00:00"),
                PageNumber = 2,
                PageSize = 25
            };

            var result = await _validator.ValidateAsync(mockRequest);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);

            await Task.CompletedTask;
        }
    }
}
