using GestaoCadeiras.API.Common;
using GestaoCadeiras.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDataContexts();
builder.AddDocumentation();
builder.AddServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.MapEndpoints();

app.Run();
