using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ViSoft.Playground.WebAPI.Extension
{
    public static class WebApplicationExtensions
    {
        public static WebApplication RegisterApiVersioning(this WebApplication app)
        {
            if (!app.Environment.IsProduction())
            {
                var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                app.UseOpenApi();
                app.UseSwaggerUI(options =>
                {
                    foreach (var groupName in apiVersionDescriptionProvider.ApiVersionDescriptions.Select(x => x.GroupName))
                    {
                        options.SwaggerEndpoint($"/swagger/{groupName}/swagger.json",
                            groupName.ToUpperInvariant());
                    }
                });
            }

            return app;
        }
    }
}
