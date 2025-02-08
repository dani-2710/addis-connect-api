using Application.Common;
using Application.Features.Organizers.Dtos;
using Application.Interfaces;

namespace Application.Features.Organizers.GetFilteredOrganizers
{
    public sealed record GetFilteredOrganizersQuery(
        string? SearchTerm,
        string? SortBy,
        string? SortOrder,
        int Page,
        int PageSize) : IQuery<PagedResult<OrganizerDto>>;
}
