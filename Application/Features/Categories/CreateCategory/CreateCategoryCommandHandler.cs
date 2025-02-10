using Application.Features.Categories.Dtos;
using Application.Interfaces;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using ErrorOr;

namespace Application.Features.Categories.CreateCategory
{
    internal sealed class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper) : ICommandHandler<CreateCategoryCommand, CategorySingleResponse>
    {
        public async Task<ErrorOr<CategorySingleResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);
            var createdCategory = await categoryRepository.CreateCategoryAsync(category);

            var createdCategoryDto = mapper.Map<CategoryDto>(createdCategory);

            return new CategorySingleResponse(createdCategoryDto);
        }
    }
}
