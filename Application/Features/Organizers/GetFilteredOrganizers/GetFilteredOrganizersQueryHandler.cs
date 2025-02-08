using Application.Common;
using Application.Features.Organizers.Dtos;
using Application.Interfaces;
using Application.Repositories;
using AutoMapper;
using ErrorOr;

namespace Application.Features.Organizers.GetFilteredOrganizers
{
    internal sealed class GetFilteredOrganizersQueryHandler(IOrganizerRepository organizerRepository, IMapper mapper) :
        IQueryHandler<GetFilteredOrganizersQuery, PagedResult<OrganizerDto>>
    {
        public async Task<ErrorOr<PagedResult<OrganizerDto>>> Handle(GetFilteredOrganizersQuery request, CancellationToken cancellationToken)
        {
            var (organizers, totalCount) = await organizerRepository.GetFilteredAsync(
                request.SearchTerm,
                request.SortBy,
                request.SortOrder,
                request.Page,
                request.PageSize);

            var allOrganizers = mapper.Map<IEnumerable<OrganizerDto>>(organizers);

            return new PagedResult<OrganizerDto>(allOrganizers, totalCount, request.Page, request.PageSize);


        }
    }
}
