namespace Unions.After;

public record LoggedIn(string UserName);
public record InvalidCredentials(int AttemptsLeft);
public record AccountLocked(DateTimeOffset Until);
public record TwoFactorRequired(string Method);

public union LoginResult(LoggedIn, InvalidCredentials, AccountLocked, TwoFactorRequired);

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