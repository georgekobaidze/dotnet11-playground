public record ParseError(string Message);

public union ParseResult<T>(T, ParseError);

public static class AgeParser
{
    public static ParseResult<int> Parse(string input)
    {
        if (!int.TryParse(input, out int age))
            return new ParseError($"'{input}' is not a number.");

        if (age is < 0 or > 150)
            return new ParseError($"{age} is not a realistic age.");

        return age;
    }
}