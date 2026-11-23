public record User(int Id, string Name);
public record UserNotFound(int Id);
public record AccessDenied(string Reason);

public union GetUserResult(User, UserNotFound, AccessDenied);

public class UserService
{
    private const int AdminId = 100;

    private readonly Dictionary<int, User> _users = new()
    {
        [1] = new User(1, "Ada"),
        [2] = new User(2, "Linus"),
        [AdminId] = new User(AdminId, "Admin"),
    };

    public GetUserResult GetUser(int id)
    {
        if (!_users.TryGetValue(id, out User? user))
            return new UserNotFound(id);

        if (user.Id == AdminId)
            return new AccessDenied("Admin profiles are private.");

        return user;
    }
}
