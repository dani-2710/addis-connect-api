using Application.Features.Categories.CreateCategory;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Categories.Dtos
{
    public sealed class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
