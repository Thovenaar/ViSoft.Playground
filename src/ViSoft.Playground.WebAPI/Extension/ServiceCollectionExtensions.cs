using Microsoft.AspNetCore.Mvc;

namespace ViSoft.Playground.WebAPI.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterApiVersioning(this IServiceCollection services)
        {
            services.AddOpenApiDocument(settings =>
            {
                settings.Title = "ViSoft.DataHub API";
                settings.Version = "V1";
                settings.Description = "ViSoft.DataHub API";
            });

            services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });
            
            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigureSwaggerOptions>();

            return services;
        }
    }
}
