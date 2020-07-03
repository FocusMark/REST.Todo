using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FocusMark.Tasks.Api
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddFocusMarkAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var authSection = configuration.GetSection("AWS:Cognito");
            var authConfiguration = new AuthorizationConfiguration();
            authSection.Bind(authConfiguration);

            var publicKeys = new List<JsonWebKey>();
            string[] validIssuers = new string[authConfiguration.TokenIssuers.Length];
            for (int index = 0; index < authConfiguration.TokenIssuers.Length; index++)
            {
                TokenIssuer issuer = authConfiguration.TokenIssuers[index];
                validIssuers[index] = issuer.Url;
                publicKeys.AddRange(issuer.Keys);
            }

            services.Configure<AuthorizationConfiguration>(configuration.GetSection("AWS:Cognito"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters.ValidIssuers = validIssuers;
                    options.TokenValidationParameters.IssuerSigningKeys = publicKeys;
                    options.TokenValidationParameters.NameClaimType = ClaimTypes.NameIdentifier;
                    options.TokenValidationParameters.ValidateAudience = false;

                    options.RequireHttpsMetadata = false;
                });

            services.AddAuthorization();

            return services;
        }
    }
}
