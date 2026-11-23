public record Disconnected;
public record Connecting(int Attempt);
public record Connected(DateTimeOffset Since);
public record Failed(string Reason);

public union ConnectionState(Disconnected, Connecting, Connected, Failed);

public static class ConnectionMachine
{
    private const int MaxAttempts = 3;

    public static ConnectionState Next(ConnectionState state, bool serverResponds) => state switch
    {
        Disconnected => new Connecting(1),
        Connecting when serverResponds => new Connected(DateTimeOffset.Now),
        Connecting c when c.Attempt < MaxAttempts => new Connecting(c.Attempt + 1),
        Connecting => new Failed($"No response after {MaxAttempts} attempts."),
        Connected when serverResponds => state,
        Connected => new Disconnected(),
        Failed => new Disconnected()
    };

    public static string Describe(ConnectionState state) => state switch
    {
        Disconnected => "Offline",
        Connecting c => $"Connecting (attempt {c.Attempt})...",
        Connected c => $"Online since {c.Since:T}",
        Failed f => $"Failed: {f.Reason}"
    };
}