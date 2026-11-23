public record Add(string Text);
public record Done(int Number);
public record ShowList;
public record Quit;
public record Invalid(string Reason);

public union Command(Add, Done, ShowList, Quit, Invalid);

public static class CommandParser
{
    public static Command Parse(string input)
    {
        string[] parts = input.Trim().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 0)
            return new Invalid("Type a command: add, done, list or quit.");

        string argument = parts.Length > 1 ? parts[1] : "";

        return parts[0].ToLowerInvariant() switch
        {
            "add" when argument.Length > 0 => new Add(argument),
            "add" => new Invalid("What should I add? Try: add Buy milk"),
            "done" when int.TryParse(argument, out int number) => new Done(number),
            "done" => new Invalid("Which item? Try: done 1"),
            "list" => new ShowList(),
            "quit" => new Quit(),
            _ => new Invalid($"Unknown command '{parts[0]}'.")
        };
    }
}

public class TodoList
{
    private readonly List<string> _items = [];

    public string Execute(Command command) => command switch
    {
        Add add => AddItem(add.Text),
        Done done => Complete(done.Number),
        ShowList => Show(),
        Quit => "Bye!",
        Invalid invalid => invalid.Reason
    };

    private string AddItem(string text)
    {
        _items.Add(text);
        return $"Added: {text}";
    }

    private string Complete(int number)
    {
        if (number < 1 || number > _items.Count)
            return $"There's no item {number}.";

        string item = _items[number - 1];
        _items.RemoveAt(number - 1);
        return $"Done: {item}";
    }

    private string Show() =>
        _items.Count == 0
            ? "Nothing to do. Nice!"
            : string.Join(Environment.NewLine, _items.Select((item, i) => $"{i + 1}. {item}"));
}