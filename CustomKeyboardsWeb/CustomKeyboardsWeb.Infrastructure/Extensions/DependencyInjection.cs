using CustomKeyboardsWeb.Application.Cummon.Abstractions;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Infrastructure.Authentication;
using CustomKeyboardsWeb.Infrastructure.Caching;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;

namespace CustomKeyboardsWeb.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var redis = ConnectionMultiplexer.Connect($"{configuration["Redis:Host"]}:{int.Parse(configuration["Redis:Port"])}");
            services.AddSingleton<IConnectionMultiplexer>(redis);

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.ConfigureOptions<JwtOptionsSetup>();
            var jwtOptions = configuration.GetSection("Jwt").Get<JwtOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
                });

            services.AddDistributedMemoryCache();
            services.AddSingleton<ICacheService, CacheService>();

            return services;
        }
    }
}
