using Application.Common;
using Application.Features.Organizers.Dtos;
using Application.Interfaces;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using ErrorOr;

namespace Application.Features.Organizers.GetAllOrganizers
{
    internal sealed class GetAllOrganizersQueryHandler(IOrganizerRepository organizerRepository, IMapper mapper) : IQueryHandler<GetAllOrganizersQuery, OrganizerListResponse>
    {
        public async Task<ErrorOr<OrganizerListResponse>> Handle(GetAllOrganizersQuery request, CancellationToken cancellationToken)
        {
            var organizers = await organizerRepository.GetAllAsync();
            var allOrganizers = mapper.Map<IEnumerable<OrganizerDto>>(organizers);
            return new OrganizerListResponse(allOrganizers);
        }
    }
}
