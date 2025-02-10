using Application.Features.Categories.Dtos;
using Application.Interfaces;
using Application.Repositories;
using AutoMapper;
using Domain.Errors;
using ErrorOr;

namespace Application.Features.Categories.UpdateCategory
{
    internal sealed class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper) : ICommandHandler<UpdateCategoryCommand, CategorySingleResponse>
    {
        public async Task<ErrorOr<CategorySingleResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updatedCategory = await categoryRepository.UpdateCategoryAsync(
                request.Id,
                request.Name,
                request.Icon,
                request.Status);

            if(updatedCategory == null) return CategoryErrors.CategoryNotFound;

            var updatedCategoryDto = mapper.Map<CategoryDto>(updatedCategory);

            return new CategorySingleResponse(updatedCategoryDto);
        }
    }
}
