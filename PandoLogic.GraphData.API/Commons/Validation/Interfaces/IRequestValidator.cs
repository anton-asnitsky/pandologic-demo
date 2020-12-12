using FluentValidation.Results;
using System.Threading.Tasks;

namespace Commons.Validation.Interfaces
{
    public interface IRequestValidator
    {
        Task<ValidationResult> Validate<T>(T instance);
    }
}
