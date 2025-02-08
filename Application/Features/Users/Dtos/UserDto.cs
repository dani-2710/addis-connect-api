namespace Application.Features.Users.Dtos
{
    public sealed record UserDto(Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Status,
        DateTime CreatedAt,
        DateTime UpdatedAt
        );
}
