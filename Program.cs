

using GameApi.Data;
using GameApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRepositories(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Services.InitializedDb();

// Configu XIVre the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello Word 1");

app.MapGameEndpoints();

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
