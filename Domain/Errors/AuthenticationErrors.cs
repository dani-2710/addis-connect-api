using ErrorOr;

namespace Domain.Errors
{
    public static class AuthenticationErrors
    {
        public static Error InvalidCredentials => Error.Validation("Authentication.InvalidCred", "Invalid Credentials");
        public static Error RefreshTokenExpired => Error.Unauthorized("Authentication.ExpiredRefreshToken", "The refresh token has expired");
    }
}
