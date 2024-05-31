var builder = WebApplication.CreateBuilder(args);
// Add Service to the container
var app = builder.Build();

//configure the http request pipeline


app.Run();
