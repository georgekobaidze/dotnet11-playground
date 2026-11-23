var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<UserService>();

var app = builder.Build();

app.MapGet("/users/{id}", (int id, UserService users) =>
    users.GetUser(id) switch
    {
        User user => Results.Ok(user),
        UserNotFound notFound => Results.NotFound($"User {notFound.Id} doesn't exist."),
        AccessDenied denied => Results.Problem(denied.Reason, statusCode: StatusCodes.Status403Forbidden)
    });

app.Run();