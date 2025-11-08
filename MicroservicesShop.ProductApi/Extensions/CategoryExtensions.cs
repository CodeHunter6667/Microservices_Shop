using MicroservicesShop.ProductApi.DTOs;
using MicroservicesShop.ProductApi.Models;

namespace MicroservicesShop.ProductApi.Extensions;

public static class CategoryExtensions
{
    public static Category MapToCategory(this CategoryDTO dto)
    {
        return new Category
        {
            Id = dto.Id,
            Name = dto.Name,
            Products = dto.Products
        };
    }

    public static CategoryDTO MapToDTO(this Category category)
    {
        return new CategoryDTO
        {
            Id = category.Id,
            Name = category.Name,
            Products = category.Products
        };
    }
}
