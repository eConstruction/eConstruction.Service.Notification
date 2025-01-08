using Microsoft.OpenApi.Models;

namespace eConstruction.Service.Notification.Modules.Swagger
{
    /// <summary>
    /// SwaggerExtensions extensions
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// AddSwagger method.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                // Created the Swagger document
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "Version .Net 9.0.x",
                    Title = "Swagger UI Personalized .Net 9",
                    Description = " Thanks for sharing.",
                    TermsOfService = new Uri(""),
                    Contact = new OpenApiContact
                    {
                        Name = "",
                        Url = new Uri("")
                    },

                    License = new OpenApiLicense
                    {
                        Name = "",
                        Url = new Uri("")
                    }
                });

                // form 2 to generate the swagger documentation
                foreach (var name in Directory.GetFiles(AppContext.BaseDirectory, "*.XML", SearchOption.TopDirectoryOnly))
                {
                    c.IncludeXmlComments(filePath: name);
                }

                // second form to give Authorization with out whrite the world Bearer
                var securityScheme = new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT" // Optional
                };

                var securityRequirement = new OpenApiSecurityRequirement
                {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "bearerAuth"
                                }
                            },
                            new string[] {}
                        }
                    };
                c.AddSecurityDefinition("bearerAuth", securityScheme);
                c.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }
    }
}
