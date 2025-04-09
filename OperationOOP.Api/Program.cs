using OperationOOP.Api.Configuration;
using OperationOOP.Core.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Tjänster
builder.Services.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoints
app.MapAllEndpoints();
var db = app.Services.CreateScope().ServiceProvider.GetRequiredService<IDatabase>();
DatabaseSeeder.Seed(db);
app.Run();