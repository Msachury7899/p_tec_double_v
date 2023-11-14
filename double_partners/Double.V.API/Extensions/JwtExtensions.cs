using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Double.V.API.Settings;

namespace Double.V.API.Extensions
{
      public  static partial class Extensions
        {
            public static IServiceCollection AddJWT(this IServiceCollection services)
            {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>()!;
            JwtSettings jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>()!;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)                    
                    .AddJwtBearer(o =>
                    {

                        o.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidIssuer = jwtSettings.Issuer,
                            ValidateIssuer = true,
                            ValidAudience = jwtSettings.Audience,
                            ValidateAudience = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                            ValidateIssuerSigningKey = true
                        };
                  });

                return services;
            }

        }

}
