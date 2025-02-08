using Application.Features.Organizers.Dtos;
using Application.Interfaces;
using Application.Repositories;
using AutoMapper;
using Domain.Errors;
using ErrorOr;

namespace Application.Features.Organizers.UpdateOrganizer
{
    internal sealed class UpdateOrganizerCommandHandler(IOrganizerRepository organizerRepository, IMapper mapper) : ICommandHandler<UpdateOrganizerCommand, OrganizerSingleResponse>
    {
        public async Task<ErrorOr<OrganizerSingleResponse>> Handle(UpdateOrganizerCommand request, CancellationToken cancellationToken)
        {
            var updatedOrganizer = await organizerRepository.UpdateAsync(
                request.Id,
                request.Name,
                request.Email,
                request.PhoneNumber,
                request.Status);

            if(updatedOrganizer == null) return OrganizerErrors.OrganzierNotFound;

            var updatedOrganizerDto = mapper.Map<OrganizerDto>(updatedOrganizer);

            return new OrganizerSingleResponse(updatedOrganizerDto);
        }
    }
}
