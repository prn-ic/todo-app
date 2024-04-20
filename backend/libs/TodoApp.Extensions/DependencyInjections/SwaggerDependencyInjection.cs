using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class SwaggerDependencyInjection
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, string serviceName = "")
    {
        services.AddSwaggerGen(c =>
        {

            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Version = "v1",
                Title = "API documentation",
                Description = "Документация для работы с API " + serviceName
            });


            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "Jwt",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
             Array.Empty<string>()
          }
        });

            var basePath = AppContext.BaseDirectory;
            if (!serviceName.IsNullOrEmpty())
              serviceName += ".";
              
            var xmlPath = Path.Combine(basePath, serviceName + "WebApi.xml");
            c.IncludeXmlComments(xmlPath);
        });

        return services;
    }
    }
}