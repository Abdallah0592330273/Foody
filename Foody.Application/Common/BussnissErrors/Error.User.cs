using ErrorOr;

namespace Foody.Application.Common.BussnissErrors;

public static class Errors
{
    public static class User
    {
        public static Error AlreadyExists => Error.Conflict(
            code: "User.AlreadyExists",
            description: "User with given email already exists");
        public static Error InvalidCredentials=>Error.Validation(
            code: "User.InvalidCredentials",
            description: "Invalid credentials");
    };
}
