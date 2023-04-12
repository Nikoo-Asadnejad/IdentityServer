using IdentityServer4.Models;
namespace IdentityServer.Configurations;

public static class IdentityConfig
{
    
    
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("api1", "My API")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "web-client",
                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.Code,
                
                // secret for authentication
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                
                // scopes that client has access to
                AllowedScopes = { "api1" },
                RequirePkce = true,
                RequireConsent = false,
                RequireClientSecret = false,
                AllowAccessTokensViaBrowser = true,
                
            }
        };

    public static IEnumerable<IdentityResource> Resources =>
        new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
}