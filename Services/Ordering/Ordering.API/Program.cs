using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
// Add Service to the container
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();



var app = builder.Build();

//configure the http request pipeline


app.Run();
