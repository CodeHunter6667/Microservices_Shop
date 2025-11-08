using MicroservicesShop.ProductApi.Commom;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigurations();
builder.AddDbContexts();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
