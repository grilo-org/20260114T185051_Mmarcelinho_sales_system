using FluentValidation;
using SalesSystem.Application.Common.Exceptions;

namespace SalesSystem.Application.Common.Validation;

public static class ValidatorExtensions
{
    public static async Task ValidateAndThrowAsync<T>(
        this IValidator<T> validator,
        T instance)
    {
        var result = await validator.ValidateAsync(instance);

        if (!result.IsValid)
            throw new ApplicationValidationException(result.Errors);
    }
}
