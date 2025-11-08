using MicroservicesShop.ProductApi.Data;
using MicroservicesShop.ProductApi.Models;
using MicroservicesShop.ProductApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesShop.ProductApi.Repository;

public class CategoryRepository(ProductDbContext context) : ICategoryRepository
{
    public async Task<Category> Create(Category category)
    {
        context.Categories.Add(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<bool> Delete(int id)
    {
        var category = await context.Categories.FindAsync(id);
        if (category == null)
        {
            return false;
        }
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Category>> GetAll()
        => await context.Categories.ToListAsync();

    public async Task<Category> GetById(int id)
        => await context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<Category>> GetCategoriesProducts()
    {
        return await context.Categories
            .Include(c => c.Products)
            .ToListAsync();
    }

    public async Task<Category> Update(Category category)
    {
        context.Entry(category).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return category;
    }
}
