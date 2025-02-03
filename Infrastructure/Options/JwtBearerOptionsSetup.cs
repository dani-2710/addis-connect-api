using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Options
{
    public class JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions) : IConfigureNamedOptions<JwtBearerOptions>
    {
        public void Configure(string? name, JwtBearerOptions options)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtOptions.Value.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtOptions.Value.Audience,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.Secret))
            };

            options.Events = new JwtBearerEvents
            {
                OnChallenge = context =>
                {
                    context.HandleResponse();

                    var problemDetails = new ProblemDetails
                    {
                        Title = "Unauthorized",
                        Status = StatusCodes.Status401Unauthorized,
                        Detail = "You are not authorized to access this resource."
                    };

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                },

                OnForbidden = async context =>
                {
                    var problemDetails = new ProblemDetails
                    {
                        Title = "Forbidden",
                        Status = StatusCodes.Status403Forbidden,
                        Detail = "You do not have permission to access this resource."
                    };

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                }
            };
        }

        public void Configure(JwtBearerOptions options)
        {
            Configure(options);
        }
    }
}
