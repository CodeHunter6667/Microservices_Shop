using MicroservicesShop.ProductApi.Data;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesShop.ProductApi.Commom;

public static class BuilderExtensions
{
    public static void AddConfigurations(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder.Configuration.GetConnectionString("ProductDbConnection") ?? string.Empty;
    }

    public static void AddDbContexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ProductDbContext>(options =>
        {
            options.UseSqlServer(Configuration.ConnectionString);
        });
    }
}
