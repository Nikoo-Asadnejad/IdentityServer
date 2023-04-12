using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Configurations;

public static class IdentityServerConfigurator
{
    
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