using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace Dene.Api.Extensions

{
    public static class JwtServiceExtensions
    {

        public static IServiceCollection AddJwt(this IServiceCollection services)
        {
            services
               .AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
               {
                   options.RequireHttpsMetadata = false;
                   options.SaveToken = true;
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = "smartsense.com.tr",
                       ValidAudience = "smartsense.com.tr",
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("-JaNdRfUjXn2r5u8x/A?D(G+KbPeShVk12346756"))
                   };
               });
            return services;
        }

        public static IApplicationBuilder UseJwt(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            return app;
        }
    }
}

    

