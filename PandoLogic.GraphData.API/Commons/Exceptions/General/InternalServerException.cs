using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Exceptions
{
    public class InternalServerException : BaseExceptionAbstract
    {
        public InternalServerException(string error) : base(error) { }

        public InternalServerException(string error, Exception innerException) : base(error, innerException) { }
    }
}
