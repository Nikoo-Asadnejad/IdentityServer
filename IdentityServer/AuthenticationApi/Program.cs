using AuthenticationApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

Configurator.Init(builder.Configuration);
// Add services to the container

Configurator.ConfigureDI(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
Configurator.ConfigurePipeline(app);

app.Run();