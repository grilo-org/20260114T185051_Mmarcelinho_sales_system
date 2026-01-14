using System.Text.RegularExpressions;
using SalesSystem.Domain.Common.Exceptions;

namespace SalesSystem.Domain.Client.ValueObjects;

public sealed record Email
{
    private static readonly Regex Regex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    public string Value { get; }

    public Email(string value)
    {
        value = (value ?? "").Trim();

        if (!Regex.IsMatch(value))
            throw new DomainException("E-mail inválido.");

        Value = value;
    }

    public override string ToString() => Value;
}