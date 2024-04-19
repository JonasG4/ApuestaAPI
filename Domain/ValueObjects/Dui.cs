using System.Text.RegularExpressions;
namespace Domain.ValueObjects;

public partial record Dui
{
    private const int DefaultLength = 10;

    private const string Pattern = @"^\d{8}-\d{1}$";

    private Dui(string value) => Value = value;

    public static Dui? Create(string value)
    {
        if (string.IsNullOrEmpty(value) || !DuiRegex().IsMatch(value) || value.Length != DefaultLength)
        {
            return null;
        }

        return new Dui(value);
    }

    public string Value { get; init; }

    [GeneratedRegex(Pattern)]
    private static partial Regex DuiRegex();
}
