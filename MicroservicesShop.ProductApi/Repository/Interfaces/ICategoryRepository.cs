using MicroservicesShop.ProductApi.Models;

namespace MicroservicesShop.ProductApi.Repository.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAll();
    Task<IEnumerable<Category>> GetCategoriesProducts();
    Task<Category> GetById(int id);
    Task<Category> Create(Category category);
    Task<Category> Update(Category category);
    Task<bool> Delete(int id);
}
