using Application.Features.Discounts.Dtos;
using Application.Interfaces;
using Application.Repositories;
using AutoMapper;
using Domain.Errors;
using ErrorOr;

namespace Application.Features.Discounts.UpdateDiscount
{
    internal sealed class UpdateDiscountCommandHandler(IDiscountRepository discountRepository, IMapper mapper) : ICommandHandler<UpdateDiscountCommand, DiscountSingleResponse>
    {
        public async Task<ErrorOr<DiscountSingleResponse>> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var updateDiscount = await discountRepository.UpdateDiscountAsync(
                request.Id,
                request.AmountType,
                request.Amount,
                request.ValidFrom,
                request.ValidTo);

            if(updateDiscount == null) return DiscountErrors.DiscountNotFound;

            var updateDiscountDto = mapper.Map<DiscountDto>(updateDiscount);

            return new DiscountSingleResponse(updateDiscountDto);
        }
    }
}
