using IdentityServer.Configurations;

var builder = WebApplication.CreateBuilder(args);
ConfigurationHelper.Init(builder.Configuration);
ConfigurationHelper.ConfigureIdentityServer4(builder.Services);

var app = builder.Build();
ConfigurationHelper.ConfigurePipeline(app);

app.Run();