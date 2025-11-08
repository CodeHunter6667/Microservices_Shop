using MicroservicesShop.ProductApi.DTOs;
using MicroservicesShop.ProductApi.Extensions;
using MicroservicesShop.ProductApi.Repository.Interfaces;
using MicroservicesShop.ProductApi.Services.Interfaces;

namespace MicroservicesShop.ProductApi.Services;

public class CategoryService(ICategoryRepository repository) : ICategoryService
{
    public async Task<CategoryDTO> AddCategory(CategoryDTO categoryDto)
    {
        var category = categoryDto.MapToCategory();
        category = await repository.Create(category);
        return category.MapToDTO();
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categories = await repository.GetAll();

        var categoriesDto = categories.Select(c => c.MapToDTO());
        return categoriesDto;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var categories = await repository.GetCategoriesProducts();
        var categoriesDto = categories.Select(c => c.MapToDTO());
        return categoriesDto;
    }

    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        var category = await repository.GetById(id);
        return category.MapToDTO();
    }

    public async Task<bool> RemoveCategory(int id)
    {
        var result =  await repository.Delete(id);
        return result;
    }

    public async Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDto)
    {
        var category = categoryDto.MapToCategory();
        category = await repository.Update(category);
        return category.MapToDTO();
    }
}
