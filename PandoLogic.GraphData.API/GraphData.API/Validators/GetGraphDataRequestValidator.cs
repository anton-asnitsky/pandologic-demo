using Commons.Validation;
using FluentValidation;
using GraphData.API.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphData.API.Validators
{
    public class GetGraphDataRequestValidator : RequestValidatorAbstarct<GetGraphDataRequest>, IValidator
    {
        public GetGraphDataRequestValidator()
        {
            RuleFor(x => x.FromDate)
                .NotEmpty()
                .WithMessage($"Field {nameof(GetGraphDataRequest.FromDate)} cannot be empty.");

            RuleFor(x => x.ToDate)
                .NotEmpty()
                .WithMessage($"Field {nameof(GetGraphDataRequest.ToDate)} cannot be empty.");

            RuleFor(x => x.FromDate)
                .LessThan(x => x.ToDate)
                .WithMessage($"Field {nameof(GetGraphDataRequest.FromDate)} cannot be greater than or equal to {nameof(GetGraphDataRequest.ToDate)}.");
        }
    }
}
