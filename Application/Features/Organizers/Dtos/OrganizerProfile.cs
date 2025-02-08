using Application.Features.Organizers.CreateOrganizer;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Organizers.Dtos
{
    public class OrganizerProfile : Profile
    {
        public OrganizerProfile()
        {
            CreateMap<CreateOrganizerCommand, Organizer>();
            CreateMap<Organizer, OrganizerDto>();
        }
    }
}
