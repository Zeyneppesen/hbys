using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Dene.Api.Extensions
{
    public static class CorsServiceExtensions
    {
        private static string AbrhUiOrigins = "_AbrhUiOrigins";

        public static IServiceCollection AddCorsForAbrh(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AbrhUiOrigins,
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            /*services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(EpilepsyUiOrigins));
            });*/

            return services;
        }

        public static IApplicationBuilder UseCorsForAbrh(this IApplicationBuilder app)
        {
            app.UseCors(AbrhUiOrigins);
            return app;
        }
    }
}