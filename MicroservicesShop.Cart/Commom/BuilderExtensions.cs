using MicroservicesShop.ProductApi.Data;
using MicroservicesShop.ProductApi.Repository;
using MicroservicesShop.ProductApi.Repository.Interfaces;
using MicroservicesShop.ProductApi.Services;
using MicroservicesShop.ProductApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesShop.ProductApi.Commom;

public static class BuilderExtensions
{
    public static void AddConfigurations(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder.Configuration.GetConnectionString("SqlConnection") ?? string.Empty;
    }

    public static void AddDbContexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ProductDbContext>(options =>
        {
            options.UseSqlServer(Configuration.ConnectionString);
        });
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IProductRepository, ProductRepository>();
        builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
        builder.Services.AddTransient<ICategoryService, CategoryService>();
        builder.Services.AddTransient<IProductService, ProductService>();
    }
}
