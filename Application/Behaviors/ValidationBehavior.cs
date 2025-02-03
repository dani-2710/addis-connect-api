using ErrorOr;
using FluentValidation;
using MediatR;

namespace Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {

        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null) => _validator = validator;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validator == null)
            {
                return await next();
            }

            var validatorResult = await _validator.ValidateAsync(request, cancellationToken);

            if(validatorResult.IsValid)
            {
                return await next();
            }

            var errors = validatorResult.Errors.ConvertAll(error => Error.Validation(error.PropertyName, error.ErrorMessage))
                                               .ToList();

            return (dynamic)errors;
        }
    }
}
