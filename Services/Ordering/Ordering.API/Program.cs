using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add Service to the container
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices (builder.Configuration)
    .AddApiServices(builder.Configuration);



var app = builder.Build();

//configure the http request pipeline
app.UseApiServices();

if (app.Environment.IsDevelopment()) 
{
    await app.InitialiseDatabaseAsync();
}


app.Run();
