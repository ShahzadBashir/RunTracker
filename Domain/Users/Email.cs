namespace Domain.Users;

public sealed record Email
{
    public Email(string? value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        Value = value;
    }
    public string Value { get; }
};