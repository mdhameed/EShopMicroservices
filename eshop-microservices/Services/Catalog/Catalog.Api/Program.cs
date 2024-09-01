var builder = WebApplication.CreateBuilder(args);

// Add Services to the Container.
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
});

var app = builder.Build();

// Configure the HTTP Request pipeline.
app.MapCarter();

app.Run();
