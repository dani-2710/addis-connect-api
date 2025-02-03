using ErrorOr;

namespace Domain.Errors
{
    public static class RoleErrors
    {
        public static Error RoleNotFound => Error.NotFound("Role.NotFound", "Role not found");
    }
}
