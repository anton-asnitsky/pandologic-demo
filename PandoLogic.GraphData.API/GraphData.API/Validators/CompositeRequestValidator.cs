using Commons.Validation.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using GraphData.API.Communication.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphData.API.Validators
{
    public class CompositeRequestValidator : IRequestValidator
    {
        private readonly Dictionary<Type, IValidator> _validators;

        public CompositeRequestValidator()
        {
            _validators = new Dictionary<Type, IValidator>
            {
                { typeof(GetGraphDataRequest), new GetGraphDataRequestValidator() },
            };
        }

        public async Task<ValidationResult> Validate<T>(T dto)
        {
            return await _validators[typeof(T)].ValidateAsync(new ValidationContext<T>(dto));
        }
    }
}
