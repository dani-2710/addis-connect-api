using ErrorOr;

namespace Domain.Errors
{
    public static class OrganizerErrors
    {
        public static Error OrganzierNotFound => Error.NotFound("Organzier.NotFound", "Organzier not found");
        public static Error OrganizerAlreadyExists => Error.Validation("Organzier.AlreadyExists", "Organzier already exists");
    }
}
