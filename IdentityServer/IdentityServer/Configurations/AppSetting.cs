namespace IdentityServer.Configurations;

public static class AppConfigurations
{
    
}

public class AppSetting
{
    public Logging Logging { get; }
    public ApiScopes ApiScopes { get; }
    public Clients Clients { get; }
}

public record Logging(
    LogLevel LogLevel
);

public record LogLevel(
    string Default,
    string Microsoft_AspNetCore
);

public record ApiScopes(
    ApiScopeSetting Api,
    ApiScopeSetting AdminApi
);

public record ApiScopeSetting(
    string Name,
    string DisplayName
);

public record Clients(
    ClientSetting WebSite,
    ClientSetting AdminPanel
);

public record ClientSetting(
    string Id,
    string GrantType,
    string[] AllowedScopes
);



