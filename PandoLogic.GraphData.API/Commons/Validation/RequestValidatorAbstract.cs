using FluentValidation;
using System;
using System.Linq.Expressions;

namespace Commons.Validation
{
    public abstract class RequestValidatorAbstarct<T> : AbstractValidator<T> where T : class
    {
        protected IRuleBuilderOptions<T, string> UseNotEmptyFieldValidation(Expression<Func<T, string>> predicate, string message)
        {
            return RuleFor(predicate).NotEmpty().WithMessage(message);
        }

        protected IRuleBuilderOptions<T, string> UseRegexValidation(Expression<Func<T, string>> predicate, string regex, string message)
        {
            return RuleFor(predicate).Matches(regex).WithMessage(message);
        }

        protected IRuleBuilderOptions<T, int> UseGreaterThan(Expression<Func<T, int>> predicate, int lowerBound, string message)
        {
            return RuleFor(predicate).GreaterThan(lowerBound).WithMessage(message);
        }
    }
}
