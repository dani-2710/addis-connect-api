using Application.Features.Discounts.CreateDiscount;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Discounts.Dtos
{
    public sealed class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<CreateDiscountCommand, Discount>();
            CreateMap<Discount, DiscountDto>();
        }
    }
}
