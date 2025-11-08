using MicroservicesShop.ProductApi.Data;
using MicroservicesShop.ProductApi.Models;
using MicroservicesShop.ProductApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesShop.ProductApi.Repository;

public class ProductRepository(ProductDbContext context) : IProductRepository
{
    public async Task<Product> Create(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<bool> Delete(int id)
    {
        var product = await GetById(id);
        if (product == null)
            return false;

        context.Products.Remove(product);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Product>> GetAll()
        => await context.Products.ToListAsync();

    public async Task<Product> GetById(int id)
        => await context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

    public async Task<Product> Update(Product product)
    {
        context.Entry(product).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return product;
    }
}
