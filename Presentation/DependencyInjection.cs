using Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Presentation.Middlewares;

namespace Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddExceptionHandler<ExceptionHandlerMiddleware>();
            services.AddProblemDetails();

            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
            services.AddAuthorization();
            
            return services;
        }
    }
}
