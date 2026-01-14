using FluentValidation.Results;

namespace SalesSystem.Application.Common.Exceptions;

public sealed class ApplicationValidationException : ApplicationException
{
    public IReadOnlyList<string> Errors { get; }

    public ApplicationValidationException(string message)
        : base(message) { }

    public ApplicationValidationException(IEnumerable<ValidationFailure> failures)
        : base("Erro de validação.")
    {
        Errors = [.. failures.Select(f => f.ErrorMessage)];
    }
}
