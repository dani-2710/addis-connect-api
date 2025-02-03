using ErrorOr;

namespace Domain.Errors
{
    public static class UserErrors
    {
        public static Error UserNotFound => Error.NotFound("User.NotFound", "User not found");
        public static Error UserAlreadyExists => Error.NotFound("User.AlreadyExists", "User already exists");
        public static Error UserUnAuthenticated => Error.Unauthorized("User.Unauthorized", "User is not authorized");
        public static Error InvalidUserId => Error.Validation("User.InvalidUserId", "User id is not valid");
    }
}
