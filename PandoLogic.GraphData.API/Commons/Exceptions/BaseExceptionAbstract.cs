using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons.Exceptions
{
    public abstract class BaseExceptionAbstract : Exception
    {
        public BaseExceptionAbstract(
            string error,
            Exception innerException = null) :
            base(error, innerException)
        { }

        public BaseExceptionAbstract(
            IList<ValidationFailure> errors,
            Exception innerException = null) :
            base(ToErrorString(errors), innerException)
        { }

        private static string ToErrorString(IList<ValidationFailure> errors) =>
            "[" + string.Join(",", errors?.Select(x => x.ErrorMessage)) + "]";
    }
}
