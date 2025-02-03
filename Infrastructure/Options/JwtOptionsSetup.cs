using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Options
{
    public class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
    {
        private const string sectionName = "JwtSettings";

        public void Configure(JwtOptions options)
        {
            configuration.GetSection(sectionName).Bind(options);
        }
    }
}
