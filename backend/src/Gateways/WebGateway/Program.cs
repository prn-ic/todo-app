using Ocelot.DependencyInjection;
using Ocelot.Middleware;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("ocelot.json")
            .Build();

        string localAllowSpecificOrigins = "lan_allow_specific_origins";

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                localAllowSpecificOrigins,
                policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((hosts) => true);
                }
            );
        });

        builder.Services.AddOcelot(configuration);

        var app = builder.Build();

        app.UseCors(localAllowSpecificOrigins);
        app.UseOcelot().Wait();
        app.UseAuthorization();

        app.Run();
    }
}
