namespace Application.Features.Organizers.Dtos
{
    public sealed record OrganizerListResponse(IEnumerable<OrganizerDto> Organizers);
}
