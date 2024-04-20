using Cards.Persistense.Data;
using Microsoft.EntityFrameworkCore;
using TodoApp.Extensions.Middlewares;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration.AddJsonFile("appsettings.json").AddEnvironmentVariables();

        builder.Services.AddApplicationLayer();
        builder.Services.AddPersistenseLayer(builder.Configuration);
        builder
            .Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    Dictionary<string, string[]> errorsDict = new Dictionary<string, string[]>();

                    var errorsTypes = context.ModelState.Keys.ToArray();

                    for (int i = 0; i < errorsTypes.Length; i++)
                    {
                        List<string> errors = new List<string>();

                        foreach (var error in context.ModelState[errorsTypes[i]]!.Errors)
                            errors.Add(error.ErrorMessage);

                        if (errorsTypes[i] == "")
                            errorsDict.Add("General", errors.ToArray());
                        else
                            errorsDict.Add(errorsTypes[i], errors.ToArray());
                    }

                    throw new TodoApp.Exceptions.HttpClientExceptions.InvalidDataException(
                        errorsDict
                    );
                };
            });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwagger("Cards");
        builder.Services.AddJwtAuth(builder.Configuration);

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(o =>
        {
            o.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });
        
        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }
            catch { }
            finally { }
        }

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
