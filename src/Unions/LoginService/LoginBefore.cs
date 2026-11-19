namespace Unions.Before;

public abstract record LoginResult;

public sealed record LoggedIn(string UserName) : LoginResult;
public sealed record InvalidCredentials(int AttemptsLeft) : LoginResult;
public sealed record AccountLocked(DateTimeOffset Until) : LoginResult;
public sealed record TwoFactorRequired(string Method) : LoginResult;

public class AuthService
{
    private const int MaxAttempts = 3;
    private readonly HashSet<string> _twoFactorUsers = ["linus"];

    private readonly Dictionary<string, string> _passwords = new()
    {
        ["ada"] = "IWroteCodeBeforeComputersExisted",
        ["linus"] = "TalkIsCheapShowMeTheCode",
    };

    private readonly Dictionary<string, int> _failedAttempts = new();

    public LoginResult Login(string userName, string password)
    {
        int failed = _failedAttempts.GetValueOrDefault(userName);

        if (failed >= MaxAttempts)
            return new AccountLocked(DateTimeOffset.Now.AddMinutes(15));

        bool userExists = _passwords.TryGetValue(userName, out string? expectedPassword);

        if (!userExists || expectedPassword != password)
        {
            _failedAttempts[userName] = ++failed;
            return new InvalidCredentials(MaxAttempts - failed);
        }

        if (_twoFactorUsers.Contains(userName))
            return new TwoFactorRequired("Authenticator app");

        _failedAttempts.Remove(userName);
        return new LoggedIn(userName);
    }
}