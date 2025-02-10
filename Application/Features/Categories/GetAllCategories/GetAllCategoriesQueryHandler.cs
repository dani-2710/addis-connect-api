using Application.Features.Categories.Dtos;
using Application.Interfaces;
using Application.Repositories;
using AutoMapper;
using ErrorOr;

namespace Application.Features.Categories.GetAllCategories
{
    internal sealed class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IQueryHandler<GetAllCategoriesQuery, CategoryListResponse>
    {
        public async Task<ErrorOr<CategoryListResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await categoryRepository.GetAllCategoriesAsync();

            var categoriesDto = mapper.Map<IEnumerable<CategoryDto>>(categories);

            return new CategoryListResponse(categoriesDto);
        }
    }
}
