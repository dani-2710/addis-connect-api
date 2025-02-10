using Application.Features.Discounts.Dtos;
using Application.Interfaces;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using ErrorOr;

namespace Application.Features.Discounts.CreateDiscount
{
    internal sealed class CreateDiscountCommandHandler(IDiscountRepository discountRepository, IMapper mapper) : ICommandHandler<CreateDiscountCommand, DiscountSingleResponse>
    {
        public async Task<ErrorOr<DiscountSingleResponse>> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = mapper.Map<Discount>(request);

            var createdDiscount = await discountRepository.CreateDiscountAsync(discount);

            var createdDiscountDto = mapper.Map<DiscountDto>(createdDiscount);

            return new DiscountSingleResponse(createdDiscountDto);
        }
    }
}
