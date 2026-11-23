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

// // After

// using Unions.After;

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
//         TwoFactorRequired t => $"Password accepted. Enter the code from your {t.Method}."
//     };

//     Console.WriteLine(message);
//     Console.WriteLine();
// }

// ----------------------------------------------------Examples------------------------------------------------

// // Age Parser

// while (true)
// {
//     Console.Write("Enter your age: ");
//     string? input = Console.ReadLine();

//     if (input is null)
//         break; // the input stream was closed (Ctrl+Z on Windows, Ctrl+D on macOS/Linux)

//     string message = AgeParser.Parse(input) switch
//     {
//         int age => $"Got it, you're {age}.",
//         ParseError error => $"Oops: {error.Message}"
//     };

//     Console.WriteLine(message);
// }

// // State Machine

// ConnectionState state = new Disconnected();

// while (true)
// {
//     Console.WriteLine($"State: {ConnectionMachine.Describe(state)}");
//     Console.Write("Does the server respond? (y/n): ");
//     string? input = Console.ReadLine();

//     if (input is null)
//         break; // the input stream was closed (Ctrl+Z on Windows, Ctrl+D on macOS/Linux)

//     state = ConnectionMachine.Next(state, serverResponds: input.Trim().ToLower() == "y");
//     Console.WriteLine();
// }

// Command Parser

var todo = new TodoList();
Console.WriteLine("Commands: add <text>, done <number>, list, quit");

while (true)
{
    Console.Write("> ");
    string? line = Console.ReadLine();

    if (line is null)
        break; // the input stream was closed (Ctrl+Z on Windows, Ctrl+D on macOS/Linux)

    Command command = CommandParser.Parse(line);
    Console.WriteLine(todo.Execute(command));

    if (command is Quit)
        break;
}


