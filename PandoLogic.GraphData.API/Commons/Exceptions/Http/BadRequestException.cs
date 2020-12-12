using FluentValidation.Results;
using System.Collections.Generic;

namespace Commons.Exceptions.Http
{
    public class BadRequestException : BaseExceptionAbstract
    {
        public BadRequestException(string error) : base(error) { }

        public BadRequestException(IList<ValidationFailure> errors) : base(errors) { }
    }
}
