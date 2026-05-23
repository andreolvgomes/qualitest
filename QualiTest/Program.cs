using FastEndpoints;
using FastEndpoints.Swagger;
using Infra.IoC;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
builder.Services.AddInfra();

var app = builder.Build();

app.UseFastEndpoints(c =>
{
    c.Endpoints.Configurator = ep =>
    {
        ep.AllowAnonymous();
    };
});

//https://localhost:55564/swagger
app.UseSwaggerGen();

//https://localhost:55564/scalar
//app.MapScalarApiReference();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.MapGet("/warmup", () => "warmup ok");

app.Run();
