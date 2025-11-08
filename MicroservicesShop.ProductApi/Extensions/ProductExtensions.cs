using MicroservicesShop.ProductApi.DTOs;
using MicroservicesShop.ProductApi.Models;

namespace MicroservicesShop.ProductApi.Extensions;

public static class ProductExtensions
{
    public static Product MaPToProduct(this ProductDTO dto)
    {
        return new Product
        {
            Id = dto.Id,
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description,
            Stock = dto.Stock,
            ImageUrl = dto.ImageUrl,
            CategoryId = dto.CategoryId
        };
    }

    public static ProductDTO MapToDTO(this Product product)
    {
        return new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            Stock = product.Stock,
            ImageUrl = product.ImageUrl,
            CategoryId = product.CategoryId
        };
    }
}
