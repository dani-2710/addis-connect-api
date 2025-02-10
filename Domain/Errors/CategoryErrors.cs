using ErrorOr;

namespace Domain.Errors
{
    public static class CategoryErrors
    {
        public static Error CategoryNotFound => Error.NotFound("Category.NotFound", "Category not found");
    }
}
