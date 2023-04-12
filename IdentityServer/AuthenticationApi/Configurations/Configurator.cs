using System.Runtime.CompilerServices;
using IdentityServer.Configurations;

namespace AuthenticationApi.Configurations;

public static class Configurator
{
    public static AppSetting Configuration { private set; get; }
    public static void Init(IConfiguration configuration)
    {
        Configuration = new AppSetting();
        configuration.Bind(Configuration);
    }
    public static void ConfigureDI(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        IdentityServerConfigurator.ConfigureIdentityServer4(services);
    }
    public static void ConfigurePipeline(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        IdentityServerConfigurator.ConfigurePipeline(app);
    }
}