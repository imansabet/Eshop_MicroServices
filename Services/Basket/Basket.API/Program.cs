using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);

//An assembly is the compiled output of your code, typically a DLL, but your EXE is also an assembly.
//It's the smallest unit of deployment for any .NET project.

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();

//Add services to the container.
var app = builder.Build();

//Configure http request pipeline
app.MapCarter();

app.Run();
