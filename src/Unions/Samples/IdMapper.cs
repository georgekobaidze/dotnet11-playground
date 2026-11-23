public union ExternalId(int, string, Guid);

public static class IdMapper
{
    public static ExternalId Parse(string input)
    {
        input = input.Trim();

        if (int.TryParse(input, out int number))
            return number;

        if (Guid.TryParse(input, out Guid guid))
            return guid;

        return input;
    }

    public static string ToKey(ExternalId id) => id switch
    {
        int number => $"legacy-{number}",
        string code => $"crm-{code}",
        Guid guid => $"cloud-{guid:N}"
    };
}