using Application.Common;
using Application.Features.Organizers.Dtos;
using Application.Interfaces;

namespace Application.Features.Organizers.CreateOrganizer
{
    public sealed record CreateOrganizerCommand(string Name,
        string Email,
        string PhoneNumber,
        Guid UserId) : ICommand<OrganizerSingleResponse>;
}
