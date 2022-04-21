var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ISaluto, SalutoStatico>();

var app = builder.Build();

app.MapGet("/", (ISaluto saluto) => saluto.EstraiSaluto());

app.Run();
