using System.Diagnostics;

// // Before

// using Unions.Before;

// var authService = new AuthService();

// while (true)
// {
//     Console.Write("User name: ");
//     string? userName = Console.ReadLine();

//     Console.Write("Password: ");
//     string? password = Console.ReadLine();

//     if (userName is null || password is null)
//         break; // the input stream was closed (Ctrl+Z on Windows, Ctrl+D on macOS/Linux)

//     LoginResult result = authService.Login(userName, password);

//     string message = result switch
//     {
//         LoggedIn l => $"Welcome back, {l.UserName}!",
//         InvalidCredentials c => $"Wrong user name or password. {c.AttemptsLeft} attempts left.",
//         AccountLocked a => $"Too many attempts. Try again after {a.Until:t}.",
//         _ => throw new UnreachableException("Unknown error")
//     };

//     Console.WriteLine(message);
//     Console.WriteLine();
// }

// ----------------------------------------------------------------------------------------------------------

// After

using Unions.After;

var authService = new AuthService();

while (true)
{
    Console.Write("User name: ");
    string? userName = Console.ReadLine();

    Console.Write("Password: ");
    string? password = Console.ReadLine();

    if (userName is null || password is null)
        break; // the input stream was closed (Ctrl+Z on Windows, Ctrl+D on macOS/Linux)

    LoginResult result = authService.Login(userName, password);

    string message = result switch
    {
        LoggedIn l => $"Welcome back, {l.UserName}!",
        InvalidCredentials c => $"Wrong user name or password. {c.AttemptsLeft} attempts left.",
        AccountLocked a => $"Too many attempts. Try again after {a.Until:t}.",
        TwoFactorRequired t => $"Password accepted. Enter the code from your {t.Method}."
    };

    Console.WriteLine(message);
    Console.WriteLine();
}