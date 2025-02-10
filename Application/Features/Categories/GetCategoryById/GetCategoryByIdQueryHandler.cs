using Application.Features.Categories.Dtos;
using Application.Interfaces;
using Application.Repositories;
using AutoMapper;
using Domain.Errors;
using ErrorOr;

namespace Application.Features.Categories.GetCategoryById
{
    internal sealed class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IQueryHandler<GetCategoryByIdQuery, CategorySingleResponse>
    {
        public async Task<ErrorOr<CategorySingleResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetCategoryByIdAsync(request.Id);

            if(category == null) return CategoryErrors.CategoryNotFound;

            var categoryDto = mapper.Map<CategoryDto>(category);
            return new CategorySingleResponse(categoryDto);
        }
    }
}
