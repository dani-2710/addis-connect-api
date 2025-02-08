using Application.Common;
using Application.Features.Organizers.CreateOrganizer;
using Application.Features.Organizers.Dtos;
using Application.Interfaces;
using Application.Repositories;
using AutoMapper;
using Domain.Constants;
using Domain.Entities;
using Domain.Errors;
using ErrorOr;

namespace Application.Features.Organziers.CreateOrganizer
{
    internal sealed class CreateOrganizerCommandHandler(IOrganizerRepository organizerRepository, IUserRepository userRepository, IMapper mapper) : ICommandHandler<CreateOrganizerCommand, OrganizerSingleResponse>
    {
        public async Task<ErrorOr<OrganizerSingleResponse>> Handle(CreateOrganizerCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByIdAsync(request.UserId);
            if (user == null) return UserErrors.UserNotFound;

            var existedOrganizer = await organizerRepository.GetByEmailAsync(request.Email);
            if (existedOrganizer != null) return OrganizerErrors.OrganizerAlreadyExists;

            var role = await userRepository.GetRoleByNameAsync(UserRoles.Organizer);
            if (role == null) return RoleErrors.RoleNotFound;

            var organizer = mapper.Map<Organizer>(request);

            var createdOrganizer = await organizerRepository.CreateAsync(organizer);
            var createdOrganizerDto = mapper.Map<OrganizerDto>(createdOrganizer);


            await userRepository.CreateUserRoleAsync(new UserRole
            {
                RoleId = role.Id,
                UserId = createdOrganizer.UserId,
            });

            return new OrganizerSingleResponse(createdOrganizerDto);
        }
    }
}
