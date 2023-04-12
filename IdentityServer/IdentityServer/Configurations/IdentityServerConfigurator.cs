using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Configurations;

public static class IdentityServerConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<IdentityDbContext>(options => options.UseInMemoryDatabase("Dev"));
        
        services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
          
        })
            .AddEntityFrameworkStores<IdentityDbContext>();
        
       
    }
    public static void ConfigureIdentityServer4(IServiceCollection services)
    {
        services.AddIdentityServer()
            .AddAspNetIdentity<IdentityUser>()
            .AddDeveloperSigningCredential()
            .AddInMemoryApiScopes(IdentityConfig.ApiScopes)
            .AddInMemoryClients(IdentityConfig.Clients);
    }
    public static void ConfigurePipeline(WebApplication app)
    {
        app.UseAuthentication();
        app.UseIdentityServer();
        app.UseAuthorization();
    }
}