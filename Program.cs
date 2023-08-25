

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var route = builder.Build();

// Configu XIVre the HTTP request pipeline.
if (route.Environment.IsDevelopment())
{
    route.UseSwagger();
    route.UseSwaggerUI();
}

route.MapGet("/", () => "Hello Word 1");



route.UseHttpsRedirection();


route.UseAuthorization();

route.MapControllers();

route.Run();
