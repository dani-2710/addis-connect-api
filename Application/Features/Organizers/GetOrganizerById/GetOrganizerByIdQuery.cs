using Application.Common;
using Application.Features.Organizers.Dtos;
using Application.Interfaces;

namespace Application.Features.Organizers.GetOrganizerById
{
    public sealed record GetOrganizerByIdQuery(Guid Id) : IQuery<OrganizerSingleResponse>;
}
