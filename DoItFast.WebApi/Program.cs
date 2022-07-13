using DoItFast.Application;
using DoItFast.Application.Helpers;
using DoItFast.Infrastructure.Identity;
using DoItFast.Infrastructure.Persistence;
using DoItFast.Infrastructure.Shared;
using DoItFast.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSharedInfrastructureServices();
builder.Services.AddPersistenceInfrastructureServices(builder.Configuration);
builder.Services.AddIdentityInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationLayerServices(builder.Configuration);
builder.Services.AddWebApiServices();

// Add middlewares.

await using var app = builder.Build();

Task.Run(async () => await app.Services.ApplyPendingChanges(default)).Wait();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerExtension();
}

app.UseErrorHandlingMiddleware();
app.UseCors("AllowOrigin");
app.UseHttpsRedirection();
app.UseRouting();

//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.RunAsync();
