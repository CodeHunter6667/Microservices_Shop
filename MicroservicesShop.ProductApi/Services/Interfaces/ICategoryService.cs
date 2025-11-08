using MicroservicesShop.ProductApi.DTOs;

namespace MicroservicesShop.ProductApi.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
    Task<CategoryDTO> GetCategoryById(int id);
    Task<CategoryDTO> AddCategory(CategoryDTO categoryDto);
    Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDto);
    Task<bool> RemoveCategory(int id);
}
