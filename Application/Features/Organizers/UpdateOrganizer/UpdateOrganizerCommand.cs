using Application.Features.Organizers.Dtos;
using Application.Interfaces;

namespace Application.Features.Organizers.UpdateOrganizer
{
    public sealed record UpdateOrganizerCommand(
        Guid Id,
        string? Name,
        string? Email,
        string? PhoneNumber,
        string? Status) : ICommand<OrganizerSingleResponse>;
}
