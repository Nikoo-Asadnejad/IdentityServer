namespace IdentityServer.Configurations;

public static class ConfigurationHelper
{
    public static AppSetting Configuration { private set; get; }
    public static void Init(IConfiguration configuration)
    {
        Configuration = new AppSetting();
        configuration.Bind(Configuration);
    }
    public static void ConfigureIdentityServer4(IServiceCollection services)
    {
        services.AddIdentityServer()
            .AddDeveloperSigningCredential()
            .AddInMemoryApiScopes(IdentityConfig.ApiScopes)
            .AddInMemoryClients(IdentityConfig.Clients);
    }

    public static void ConfigurePipeline(WebApplication app)
    {
        app.UseIdentityServer();
    }
}