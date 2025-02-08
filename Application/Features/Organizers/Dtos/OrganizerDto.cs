using Application.Features.Users.Dtos;

namespace Application.Features.Organizers.Dtos
{
    public sealed record OrganizerDto(Guid Id,
        string Name,
        string Email,
        string PhoneNumber,
        string Status,
        Guid UserId,
        DateTime CreatedAt,
        DateTime UpdatedAt
        );
}
