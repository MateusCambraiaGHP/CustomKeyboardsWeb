using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CustomKeyboardsWeb.Infrastructure.Authentication

{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private readonly IConfiguration _configuration;
        private readonly string SectionName = "JwtOptions";

        public JwtOptionsSetup(IConfiguration configuration) => _configuration = configuration;

        public void Configure(JwtOptions options) => _configuration.GetSection(SectionName).Bind(options);
    }
}
