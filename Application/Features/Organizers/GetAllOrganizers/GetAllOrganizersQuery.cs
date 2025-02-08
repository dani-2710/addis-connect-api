using Application.Common;
using Application.Features.Organizers.Dtos;
using Application.Interfaces;

namespace Application.Features.Organizers.GetAllOrganizers
{
    public sealed record GetAllOrganizersQuery() : IQuery<OrganizerListResponse>;
}
