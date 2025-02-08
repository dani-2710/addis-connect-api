using Application.Common;
using Application.Features.Organizers.Dtos;
using Application.Interfaces;
using Application.Repositories;
using AutoMapper;
using Domain.Errors;
using ErrorOr;

namespace Application.Features.Organizers.GetOrganizerById
{
    internal sealed class GetOrganizerByIdQueryHandler(IOrganizerRepository organizerRepository, IMapper mapper) : IQueryHandler<GetOrganizerByIdQuery, OrganizerSingleResponse>
    {
        public async Task<ErrorOr<OrganizerSingleResponse>> Handle(GetOrganizerByIdQuery request, CancellationToken cancellationToken)
        {
            var organizer = await organizerRepository.GetByIdAsync(request.Id);

            if (organizer == null) return OrganizerErrors.OrganzierNotFound;

            var organizerDto = mapper.Map<OrganizerDto>(organizer);

            return new OrganizerSingleResponse(organizerDto);
        }
    }
}
